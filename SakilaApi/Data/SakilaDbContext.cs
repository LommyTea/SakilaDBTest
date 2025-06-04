using Microsoft.EntityFrameworkCore;
using SakilaApi.Models;

namespace SakilaApi.Data
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
    }
}
