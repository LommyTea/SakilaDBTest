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
        public DbSet<Film> Films { get; set; }

        public DbSet<FilmActor> FilmActors { get; set; }

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmActor>()
                .HasKey(fa => new { fa.FilmId, fa.ActorId }); // Composite key

            modelBuilder.Entity<FilmActor>()
                .HasOne(fa => fa.Film)
                .WithMany(f => f.FilmActors)
                .HasForeignKey(fa => fa.FilmId);

            modelBuilder.Entity<FilmActor>()
                .HasOne(fa => fa.Actor)
                .WithMany(a => a.FilmActors)
                .HasForeignKey(fa => fa.ActorId);

              // Language → Film (1-to-many)
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Language)
                .WithMany(l => l.Films)
                .HasForeignKey(f => f.LanguageId);

            // Map table and column names if needed
            modelBuilder.Entity<Film>().ToTable("film");
            modelBuilder.Entity<Film>().Property(f => f.FilmId).HasColumnName("film_id");
            modelBuilder.Entity<Film>().Property(f => f.Title).HasColumnName("title");
            modelBuilder.Entity<Film>().Property(f => f.LanguageId).HasColumnName("language_id");

            modelBuilder.Entity<Language>().ToTable("language");
            modelBuilder.Entity<Language>().Property(l => l.LanguageId).HasColumnName("language_id");
            modelBuilder.Entity<Language>().Property(l => l.Name).HasColumnName("name");


        }
    }
}
