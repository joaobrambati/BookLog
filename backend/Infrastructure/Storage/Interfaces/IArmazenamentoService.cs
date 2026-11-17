namespace Infrastructure.Storage.Interfaces;

public interface IArmazenamentoService
{
    /// <summary>Envia o arquivo para o Storage e retorna a URL pública dele.</summary>
    Task<string> Enviar(Stream conteudo, string caminho, string contentType);

    /// <summary>Remove do Storage o arquivo da URL pública informada.</summary>
    Task Remover(string url);
}
