using Application.DTOs.Livro;
using Application.Response;

namespace Application.Services.Interfaces;

// O usuarioId vem sempre do token do usuário logado (passado pelo controller)
public interface ILivroService
{
    Task<Response<List<LivroDto>>> GetAll(int usuarioId);
    Task<Response<LivroDto>> GetById(int id, int usuarioId);
    Task<Response<LivroDto>> Create(CreateLivroDto dto, int usuarioId);
    Task<Response<LivroDto>> Update(int id, UpdateLivroDto dto, int usuarioId);
    Task<Response<bool>> Delete(int id, int usuarioId);
}
