using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.Repositories.Movies
{
    internal class MovieRepository : IMovieReadOnlyRepository, IMovieWriteOnlyRepository, IMovieUpdateOnlyRepository
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

        public async Task<List<Movie>> GetAll(byte? stars)
        {
            var query = _rateMovieDBContext.Movies.AsNoTracking();

            if (stars is >= 1 and <= 5)
                query = query.Where(movie => movie.Stars == stars);

            return await query.ToListAsync();
        }

        public async Task Add(Movie movie)
        {
            await _rateMovieDBContext.Movies.AddAsync(movie);
        }

        public async Task<Movie?> GetById(int id)
        {
            var movie = await _rateMovieDBContext.Movies.FirstOrDefaultAsync(movie => movie.Id == id);

            return movie;
        }

        public void Update(Movie movie)
        {
            _rateMovieDBContext.Movies.Update(movie);
        }
    }
}
