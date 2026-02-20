using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface ILivroRepository
{
    Task<List<Livro>> GetAll();
    Task<Livro?> GetById(int id);
    Task Create(Livro livro);
    void Update(Livro livro);
    void Delete(Livro livro);
    Task SaveChangesAsync();
}