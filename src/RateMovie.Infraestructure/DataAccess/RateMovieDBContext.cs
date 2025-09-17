using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateMovie.Domain.Entities;
using System.Xml.Linq;

namespace RateMovie.Infraestructure.DataAccess
{
    internal class RateMovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public RateMovieDBContext(DbContextOptions<RateMovieDBContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Movie>(entity =>
                {
                    EntityBuilderMovieTableAndColumns(entity);
                    EntityBuilderMovieSeed(entity);
                });
        }

        private void EntityBuilderMovieTableAndColumns(EntityTypeBuilder<Movie> entity)
        {
            entity.ToTable("Movies");

            entity.HasKey(m => m.Id);

            entity.Property(m => m.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(m => m.Comment)
                .HasMaxLength(800)
                .IsRequired(false);

            entity.Property(m => m.Stars)
                .HasColumnType("TINYINT")
                .IsRequired();

            entity.ToTable(b => b.HasCheckConstraint("CK_Movies_Stars", "Stars BETWEEN 1 AND 5"));
        }

        private void EntityBuilderMovieSeed(EntityTypeBuilder<Movie> entity)
        {
            entity.HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Batman: The Dark Knight",
                    Comment = "Great performance by Heath Ledger, one of the best superhero movies.",
                    Stars = 5
                },
                new Movie
                {
                    Id = 2,
                    Name = "Inception",
                    Comment = "Complex and intelligent film, requires the viewer's attention.",
                    Stars = 4
                },
                new Movie
                {
                    Id = 3,
                    Name = "Interstellar",
                    Comment = "Incredible visuals and a beautiful exploration of science fiction.",
                    Stars = 5
                },
                new Movie
                {
                    Id = 4,
                    Name = "The Matrix",
                    Comment = "Revolutionary sci-fi with a unique take on reality. Groundbreaking for its time.",
                    Stars = 5
                },
                new Movie
                {
                    Id = 5,
                    Name = "The Godfather",
                    Comment = "Classic mafia story, slow pacing but unmatched storytelling.",
                    Stars = 4
                },
                new Movie
                {
                    Id = 6,
                    Name = "The Room",
                    Comment = "So bad it became a cult classic. Unintentionally hilarious.",
                    Stars = 1
                },
                new Movie
                {
                    Id = 7,
                    Name = "Avengers: Endgame",
                    Comment = "Epic conclusion to a decade of Marvel movies, lots of fan service.",
                    Stars = 4
                },
                new Movie
                {
                    Id = 8,
                    Name = "Titanic",
                    Comment = "Emotional love story with spectacular visuals, though a bit too long.",
                    Stars = 3
                },
                new Movie
                {
                    Id = 9,
                    Name = "Joker",
                    Comment = "Disturbing but brilliant character study, Joaquin Phoenix delivers a masterpiece.",
                    Stars = 5
                },
                new Movie
                {
                    Id = 10,
                    Name = "Shrek",
                    Comment = "Funny, clever, and full of references. Works for both kids and adults.",
                    Stars = 4
                },
                new Movie
                {
                    Id = 11,
                    Name = "Transformers",
                    Comment = "Visually impressive but shallow story, feels repetitive.",
                    Stars = 2
                },
                new Movie
                {
                    Id = 12,
                    Name = "La La Land",
                    Comment = "Beautiful musical, strong performances, bittersweet ending.",
                    Stars = 4
                },
                new Movie
                {
                    Id = 13,
                    Name = "Cats",
                    Comment = "Uncanny visuals and lack of coherent plot. Painful to watch.",
                    Stars = 1
                },
                new Movie
                {
                    Id = 14,
                    Name = "Suicide Squad",
                    Comment = "Chaotic story, weak villain, but some fun moments.",
                    Stars = 2
                },
                new Movie
                {
                    Id = 15,
                    Name = "Justice League (2017)",
                    Comment = "Disjointed narrative, inconsistent tone, feels rushed.",
                    Stars = 2
                },
                new Movie
                {
                    Id = 16,
                    Name = "Mortal Kombat: Annihilation",
                    Comment = "Poor acting, terrible CGI. Fans deserved better.",
                    Stars = 1
                },
                new Movie
                {
                    Id = 17,
                    Name = "Dragonball Evolution",
                    Comment = "Total disrespect to the source material, universally hated.",
                    Stars = 1
                },
                new Movie
                {
                    Id = 18,
                    Name = "Venom",
                    Comment = "Decent action, but uneven tone. Carried by Tom Hardy.",
                    Stars = 3
                },
                new Movie
                {
                    Id = 19,
                    Name = "The Amazing Spider-Man 2",
                    Comment = "Some good visuals, but overcrowded plot and wasted villains.",
                    Stars = 3
                },
                new Movie
                {
                    Id = 20,
                    Name = "Pirates of the Caribbean: On Stranger Tides",
                    Comment = "Charming moments, but franchise fatigue shows.",
                    Stars = 3
                }
            );
        }
    }
}
