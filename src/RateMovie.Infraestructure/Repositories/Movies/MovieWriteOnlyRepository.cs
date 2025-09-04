using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.Repositories.Movies
{
    internal class MovieWriteOnlyRepository : IMovieWriteOnlyRepository
    {
        private readonly RateMovieDBContext _rateMovieDBContext;
        public MovieWriteOnlyRepository(RateMovieDBContext rateMovieDBContext)
        {
            _rateMovieDBContext = rateMovieDBContext;
        }

        public async Task Register(Movie movie)
        {
            await _rateMovieDBContext.Movies.AddAsync(movie);
            await _rateMovieDBContext.SaveChangesAsync();
        }
    }
}
