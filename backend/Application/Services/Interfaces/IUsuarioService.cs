using Application.DTOs.Usuario;
using Application.Response;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces;

public interface IUsuarioService
{
    Task<Response<UsuarioDto>> GetById(int id);
    Task<Response<UsuarioDto>> Update(int id, UpdateUsuarioDto dto);
    Task<Response<UsuarioDto>> AtualizarFoto(int id, IFormFile arquivo);
}
