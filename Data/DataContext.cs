using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Entites;
using System.Text;

namespace SuperheroAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Superhero> SuperHeroes { get; set; }
        public DbSet<Villain> Villains { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Id = "a1b2c3d4-e5f6-7890-abcd-1234567890ab", // ثابت
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Id = "b2c3d4e5-f678-9012-abcd-2345678901bc", // ثابت
            Name = "User",
            NormalizedName = "USER"
        },
    };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
