using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetById(int id);
    void Update(Usuario usuario);
    Task SaveChangesAsync();
}
