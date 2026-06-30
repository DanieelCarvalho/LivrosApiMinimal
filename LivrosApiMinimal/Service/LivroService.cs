using LivrosApiMinimal.Context;
using LivrosApiMinimal.Model;
using Microsoft.EntityFrameworkCore;

namespace LivrosApiMinimal.Service;

public class LivroService : ILivroService
{
    private readonly AppDbContext _context;

    public LivroService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Livro> AddLivroAsync(Livro livro)
    {
        if (livro is null)
            throw new ArgumentNullException(nameof(livro));

        _context.Add(livro);

         await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<Livro> DeleteLivroAsync(int id)
    {
       var livro =  await _context.Livros.FindAsync(id);
        if(livro == null)
        {
            throw new ArgumentNullException(nameof(livro));
        }
        _context.Remove(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<Livro?> GetLivroByIdAsync(int id)
    {
        var livro = await _context.Livros.AsNoTracking().FirstOrDefaultAsync(livro => livro.Id == id);

        return livro;

    }

    public async Task<IEnumerable<Livro>> GetLivrosAsync()
    {
        return await _context.Livros.AsNoTracking().ToListAsync();
    }

    public async Task<Livro?> UpdateLivroAsync(Livro livro)
    {
        if (livro is null)
            throw new ArgumentNullException(nameof(livro));

        _context.Update(livro);
       await _context.SaveChangesAsync();

        return livro;
    }
}
