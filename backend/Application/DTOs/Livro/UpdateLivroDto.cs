using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.DTOs.Livro;

public class UpdateLivroDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
    public string Nome { get; set; } = null!;
    public string? Autor { get; set; }
    public string? Sinopse { get; set; }
    public int? AnoPublicacao { get; set; }

    public DateOnly? DataInicioLeitura { get; set; }
    public DateOnly? DataFimLeitura { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O número de páginas deve ser maior que zero.")]
    public int? NumeroPaginas { get; set; }

    [EnumDataType(typeof(Categoria), ErrorMessage = "Categoria inválida.")]
    public Categoria Categoria { get; set; }

    [Range(0.0, 5.0, ErrorMessage = "A avaliação deve estar entre 0 e 5.")]
    public decimal? Avaliacao { get; set; }
    [EnumDataType(typeof(StatusLeitura), ErrorMessage = "Status de leitura inválido.")]
    public StatusLeitura Status { get; set; }
    public string? Review { get; set; }

    [EnumDataType(typeof(TipoLivro), ErrorMessage = "Tipo de livro inválido.")]
    public TipoLivro TipoLivro { get; set; }
    [EnumDataType(typeof(TipoFisico), ErrorMessage = "Tipo físico inválido.")]
    public TipoFisico? TipoFisico { get; set; }
    [EnumDataType(typeof(TipoDigital), ErrorMessage = "Tipo digital inválido.")]
    public TipoDigital? TipoDigital { get; set; }
    [EnumDataType(typeof(TipoAudio), ErrorMessage = "Tipo de áudio inválido.")]
    public TipoAudio? TipoAudio { get; set; }

    [Range(typeof(decimal), "0", "9999999999999999.99", ParseLimitsInInvariantCulture = true, ErrorMessage = "O valor não pode ser negativo.")]
    public decimal Valor { get; set; }
    public string? PlataformaCompra { get; set; }
    [Url(ErrorMessage = "O link deve ser uma URL válida.")]
    public string? Link { get; set; }

    public bool Favorito { get; set; }
}
