using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RateMovie.Domain.Entities;

namespace RateMovie.Infraestructure.DataAccess
{
    public class RateMovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            var mySqlVersion = new MySqlServerVersion(new Version(8,0,42));

            // I'll be making a dependency injection and use the appsettings variable ConnectionDBMySql
            // from the builder config.
            var connectionString = "server=localhost;user=root;password=1a2b3c4d!@#;database=RateMovieDB";

            opt.UseMySql(connectionString, mySqlVersion)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
