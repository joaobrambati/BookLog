using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetById(int id)
        => await _context.Usuarios.FindAsync(id);

    public void Update(Usuario usuario)
        => _context.Usuarios.Update(usuario);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

}
