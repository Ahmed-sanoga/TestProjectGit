using SuperheroAPI.Entites;

namespace SuperheroAPI.Repositories
{
    public interface ISuperheroRepository
    {
        Task<List<Superhero>> GetAllAsync();
        Task<Superhero?> GetByIdAsync(int id);
        Task AddAsync(Superhero hero);
        Task UpdateAsync(Superhero hero);
        Task DeleteAsync(Superhero hero);
    }
}
