using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.Repositories.Movies
{
    public class MovieWriteOnlyRepository : IMovieWriteOnlyRepository
    {
        public async Task Register(Movie movie)
        {
            var dbContext = new RateMovieDBContext();

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }
    }
}
