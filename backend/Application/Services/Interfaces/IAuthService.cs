using Application.DTOs.Auth;
using Application.Response;

namespace Application.Services.Interfaces;

public interface IAuthService
{
    Task<Response<AuthResponseDto>> Registrar(RegistrarDto dto);
    Task<Response<AuthResponseDto>> Login(LoginDto dto);
}
