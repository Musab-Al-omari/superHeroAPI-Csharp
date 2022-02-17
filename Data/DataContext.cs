
using Microsoft.EntityFrameworkCore;

namespace superHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<SuperHero> SuperHero { get; set; }

    }
}