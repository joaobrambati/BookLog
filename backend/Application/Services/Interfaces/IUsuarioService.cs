using Application.DTOs.Usuario;
using Application.Response;

namespace Application.Services.Interfaces;

public interface IUsuarioService
{
    Task<Response<UsuarioDto>> GetById(int id);
    Task<Response<UsuarioDto>> Update(int id, UpdateUsuarioDto dto);
}
