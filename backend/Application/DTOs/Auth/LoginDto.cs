using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "O email é obrigatório.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; } = null!;
}
