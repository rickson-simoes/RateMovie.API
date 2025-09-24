using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Infrastructure.DataAccess;

namespace RateMovie.Infrastructure.Repositories.Movies
{
    internal class MovieRepository : 
        IMovieReadOnlyRepository,
        IMovieWriteOnlyRepository,
        IMovieUpdateOnlyRepository,
        IMovieDeleteOnlyRepository
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

            return await query.OrderByDescending(movie => movie.Stars).ToListAsync();
        }

        public async Task Add(Movie movie)
        {
            await _rateMovieDBContext.Movies.AddAsync(movie);
        }

        async Task<Movie?> IMovieReadOnlyRepository.GetById(int id)
        {
            var movie = await _rateMovieDBContext.Movies.AsNoTracking().FirstOrDefaultAsync(movie => movie.Id == id);

            return movie;
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

        public void Delete(Movie movie)
        {
            _rateMovieDBContext.Movies.Remove(movie);
        }
    }
}
