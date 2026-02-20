using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations;

public class LivroRepository : ILivroRepository
{
    private readonly AppDbContext _context;

    public LivroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> GetAll()
        => await _context.Livros.ToListAsync();

    public async Task<Livro?> GetById(int id)
        => await _context.Livros.FindAsync(id);

    public async Task Create(Livro livro)
        => await _context.Livros.AddAsync(livro);

    public void Update(Livro livro)
        => _context.Livros.Update(livro);

    public void Delete(Livro livro)
        => _context.Livros.Remove(livro);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

}
