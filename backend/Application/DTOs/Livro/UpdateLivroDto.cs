using Domain.Enums;

namespace Application.DTOs.Livro;

public class UpdateLivroDto
{
    public string Nome { get; set; } = null!;
    public string? Autor { get; set; }
    public string? Sinopse { get; set; }
    public int? AnoPublicacao { get; set; }

    public DateTime? DataInicioLeitura { get; set; }
    public DateTime? DataFimLeitura { get; set; }

    public int? NumeroPaginas { get; set; }

    public Categoria Categoria { get; set; }

    public decimal? Avaliacao { get; set; }
    public StatusLeitura Status { get; set; }
    public string? Review { get; set; }

    public TipoLivro TipoLivro { get; set; }
    public TipoFisico? TipoFisico { get; set; }
    public TipoDigital? TipoDigital { get; set; }
    public TipoAudio? TipoAudio { get; set; }

    public decimal Valor { get; set; }
    public string? PlataformaCompra { get; set; }
    public string? Link { get; set; }

    public bool Favorito { get; set; }
}
