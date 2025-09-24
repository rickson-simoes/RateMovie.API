using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RateMovie.Infrastructure.DataAccess;

namespace RateMovie.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public async static Task Execute(IServiceProvider service)
        {
            var dbContext = service.GetRequiredService<RateMovieDBContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
