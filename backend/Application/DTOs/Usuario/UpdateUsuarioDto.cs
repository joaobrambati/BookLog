using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Usuario;

public class UpdateUsuarioDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
    public string Nome { get; set; } = null!;

    [Range(1, 10080, ErrorMessage = "A meta semanal deve ser entre 1 minuto e 168 horas (uma semana).")]
    public int? MetaSemanalMinutos { get; set; }
}
