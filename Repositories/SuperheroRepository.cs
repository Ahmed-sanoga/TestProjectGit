using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.Entites;

namespace SuperheroAPI.Repositories
{
    public class SuperheroRepository : ISuperheroRepository
    {
        private readonly DataContext _context;

        public SuperheroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Superhero>> GetAllAsync()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<Superhero?> GetByIdAsync(int id)
        {
            return await _context.SuperHeroes.FindAsync(id);
        }

        public async Task AddAsync(Superhero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Superhero hero)
        {
            _context.SuperHeroes.Update(hero);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Superhero hero)
        {
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
        }
    }
}

