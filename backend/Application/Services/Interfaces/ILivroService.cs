using Application.DTOs.Livro;
using Application.Response;

namespace Application.Services.Interfaces;

public interface ILivroService
{
    Task<Response<List<LivroDto>>> GetAll();
    Task<Response<LivroDto>> GetById(int id);
    Task<Response<LivroDto>> Create(CreateLivroDto dto);
    Task<Response<LivroDto>> Update(int id, UpdateLivroDto dto);
    Task<Response<bool>> Delete(int id);
}
