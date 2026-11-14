using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    //public string Foto { get; set; }
    public int? MetaSemanalMinutos { get; set; }
}
