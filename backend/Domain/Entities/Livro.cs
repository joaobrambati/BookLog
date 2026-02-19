using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Livro
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
    //public string CapaImg { get; set; }
    public string? Autor { get; set; }
    public string? Sinopse { get; set; }
    public int? AnoPublicacao { get; set; }
    public DateTime? DataInicioLeitura { get; set; }
    public DateTime? DataFimLeitura { get; set; }
    public int? NumeroPaginas { get; set; }
    public Categoria Categoria { get; set; }

    [Column(TypeName = "decimal(2,1)")]
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
