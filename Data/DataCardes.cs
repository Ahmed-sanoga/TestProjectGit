using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Entites;

namespace SuperheroAPI.Data
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
    }
}