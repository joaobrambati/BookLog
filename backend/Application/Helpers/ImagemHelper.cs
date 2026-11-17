using Microsoft.AspNetCore.Http;

namespace Application.Helpers;

public static class ImagemHelper
{
    private const long TamanhoMaximoBytes = 2 * 1024 * 1024; // 2 MB

    // Tipo do arquivo -> extensão usada no nome salvo
    private static readonly Dictionary<string, string> TiposPermitidos = new()
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/webp"] = ".webp"
    };

    /// <summary>Retorna a mensagem de erro, ou null se a imagem for válida.</summary>
    public static string? Validar(IFormFile? arquivo)
    {
        if (arquivo is null || arquivo.Length == 0)
            return "Nenhuma imagem foi enviada.";

        if (arquivo.Length > TamanhoMaximoBytes)
            return "A imagem deve ter no máximo 2 MB.";

        if (!TiposPermitidos.ContainsKey(arquivo.ContentType.ToLowerInvariant()))
            return "Formato inválido. Envie uma imagem JPG, PNG ou WEBP.";

        return null;
    }

    /// <summary>Gera um nome único para o arquivo, para não sobrescrever nem pegar cache antigo.</summary>
    public static string GerarNomeArquivo(IFormFile arquivo)
        => $"{Guid.NewGuid()}{TiposPermitidos[arquivo.ContentType.ToLowerInvariant()]}";
}
