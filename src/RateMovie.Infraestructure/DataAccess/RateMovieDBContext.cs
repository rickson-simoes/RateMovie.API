using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateMovie.Domain.Entities;

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
                    EntityBuilderMovieData(entity);
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

        private void EntityBuilderMovieData(EntityTypeBuilder<Movie> entity)
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
                }
            );
        }
    }
}
