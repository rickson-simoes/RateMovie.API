using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieUpdateOnlyRepository
    {
        Task<Movie?> GetById(int id, int userId);
        void Update(Movie movie);
    }
}
