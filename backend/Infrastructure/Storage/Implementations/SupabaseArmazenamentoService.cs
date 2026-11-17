using System.Net.Http.Headers;
using Infrastructure.Storage.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Storage.Implementations;

// Envia e remove arquivos no Supabase Storage usando a API REST dele
public class SupabaseArmazenamentoService : IArmazenamentoService
{
    private readonly HttpClient _httpClient;
    private readonly string _url;
    private readonly string _bucket;

    public SupabaseArmazenamentoService(HttpClient httpClient, IConfiguration configuration)
    {
        _url = (configuration["Supabase:Url"]
            ?? throw new InvalidOperationException("Supabase:Url não configurada no user-secrets.")).TrimEnd('/');

        var secretKey = configuration["Supabase:SecretKey"]
            ?? throw new InvalidOperationException("Supabase:SecretKey não configurada no user-secrets.");

        _bucket = configuration["Supabase:Bucket"]
            ?? throw new InvalidOperationException("Supabase:Bucket não configurado no appsettings.");

        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_url}/storage/v1/");
        _httpClient.DefaultRequestHeaders.Add("apikey", secretKey);

        // Chave antiga (service_role) é um JWT e também vai no Authorization.
        // A chave nova (sb_secret_...) vai só no "apikey".
        if (secretKey.StartsWith("eyJ"))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secretKey);
    }

    public async Task<string> Enviar(Stream conteudo, string caminho, string contentType)
    {
        using var corpo = new StreamContent(conteudo);
        corpo.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        var resposta = await _httpClient.PostAsync($"object/{_bucket}/{caminho}", corpo);

        if (!resposta.IsSuccessStatusCode)
        {
            var erro = await resposta.Content.ReadAsStringAsync();
            throw new InvalidOperationException($"Erro ao enviar imagem para o Storage ({(int)resposta.StatusCode}): {erro}");
        }

        return $"{_url}/storage/v1/object/public/{_bucket}/{caminho}";
    }

    public async Task Remover(string url)
    {
        var prefixo = $"{_url}/storage/v1/object/public/{_bucket}/";

        // Só remove arquivos que estão no nosso bucket
        if (!url.StartsWith(prefixo))
            return;

        var caminho = url[prefixo.Length..];

        var resposta = await _httpClient.DeleteAsync($"object/{_bucket}/{caminho}");

        if (!resposta.IsSuccessStatusCode)
        {
            var erro = await resposta.Content.ReadAsStringAsync();
            throw new InvalidOperationException($"Erro ao remover imagem do Storage ({(int)resposta.StatusCode}): {erro}");
        }
    }
}
