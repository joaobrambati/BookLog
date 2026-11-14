using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task Create(Usuario usuario);
    Task<Usuario?> GetById(int id);
    Task<Usuario?> GetByEmail(string email);
    void Update(Usuario usuario);
    Task SaveChangesAsync();
}
