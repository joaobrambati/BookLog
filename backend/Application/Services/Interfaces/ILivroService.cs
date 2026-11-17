using Application.DTOs.Livro;
using Application.Response;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces;

public interface ILivroService
{
    Task<Response<List<LivroDto>>> GetAll(int usuarioId);
    Task<Response<LivroDto>> GetById(int id, int usuarioId);
    Task<Response<LivroDto>> Create(CreateLivroDto dto, int usuarioId);
    Task<Response<LivroDto>> Update(int id, UpdateLivroDto dto, int usuarioId);
    Task<Response<bool>> Delete(int id, int usuarioId);
    Task<Response<LivroDto>> AtualizarCapa(int id, IFormFile arquivo, int usuarioId);
}
