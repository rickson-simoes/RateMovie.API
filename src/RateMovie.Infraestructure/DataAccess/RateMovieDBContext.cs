using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;

namespace RateMovie.Infraestructure.DataAccess
{
    internal class RateMovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public RateMovieDBContext(DbContextOptions opt) : base(opt) { }
    }
}
