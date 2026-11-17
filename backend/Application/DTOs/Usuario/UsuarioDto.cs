namespace Application.DTOs.Usuario;

public class UsuarioDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? FotoUrl { get; set; }
    public int? MetaSemanalMinutos { get; set; }
}
