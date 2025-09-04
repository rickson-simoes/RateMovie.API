using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.Repositories.Movies
{
    internal class MovieReadOnlyRepository : IMovieReadOnlyRepository
    {
        private readonly RateMovieDBContext _rateMovieDBContext;

        public MovieReadOnlyRepository(RateMovieDBContext rateMovieDBContext)
        {
            _rateMovieDBContext = rateMovieDBContext;
        }

        public async Task<List<Movie>> Get()
        {
            var movies = await _rateMovieDBContext.Movies.AsNoTracking().ToListAsync();

            return movies;
        }
    }
}
