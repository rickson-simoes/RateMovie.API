using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateMovie.Domain.Entities;

namespace RateMovie.Infrastructure.DataAccess
{
    internal class RateMovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public RateMovieDBContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>(entity =>
                {
                    EntityBuilderUserTableAndColumns(entity);
                });

            modelBuilder
                .Entity<Movie>(entity =>
                {
                    EntityBuilderMovieTableAndColumns(entity);
                });
        }

        private void EntityBuilderUserTableAndColumns(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired(true);

            entity.Property(u => u.Password)
                .HasMaxLength(300)
                .IsRequired();

            entity.Property(u => u.Role)
                .HasColumnType("TINYINT")
                .IsRequired();
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

            entity.Property(m => m.Genre)
                .HasConversion<byte>()
                .HasColumnType("TINYINT")
                .IsRequired();

            entity.Property(m => m.CreatedAt)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.Property(m => m.UserId)
                .IsRequired();

            entity
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
