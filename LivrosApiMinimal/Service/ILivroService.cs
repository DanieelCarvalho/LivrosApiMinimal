using LivrosApiMinimal.Model;

namespace LivrosApiMinimal.Service;

public interface ILivroService
{
    Task<IEnumerable<Livro>> GetLivrosAsync();

    Task<Livro?> GetLivroByIdAsync(int id);

    Task<Livro> AddLivroAsync(Livro livro);

    Task<Livro?> UpdateLivroAsync(Livro livro);

    Task<Livro> DeleteLivroAsync(int id);
}
