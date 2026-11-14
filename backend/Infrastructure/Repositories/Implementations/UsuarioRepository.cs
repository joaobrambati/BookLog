using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Usuario?> GetByEmail(string email)
        => await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

    public async Task Create(Usuario usuario)
        => await _context.Usuarios.AddAsync(usuario);

    public void Update(Usuario usuario)
        => _context.Usuarios.Update(usuario);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

}
