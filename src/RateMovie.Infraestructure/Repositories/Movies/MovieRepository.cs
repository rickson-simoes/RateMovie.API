using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.Repositories.Movies
{
    internal class MovieRepository : IMovieReadOnlyRepository, IMovieWriteOnlyRepository
    {
        private readonly RateMovieDBContext _rateMovieDBContext;

        public MovieRepository(RateMovieDBContext rateMovieDBContext)
        {
            _rateMovieDBContext = rateMovieDBContext;
        }

        public async Task<List<Movie>> GetAll()
        {
            var movies = await _rateMovieDBContext.Movies.AsNoTracking().ToListAsync();

            return movies;
        }

        public async Task Add(Movie movie)
        {
            await _rateMovieDBContext.Movies.AddAsync(movie);
        }
    }
}
