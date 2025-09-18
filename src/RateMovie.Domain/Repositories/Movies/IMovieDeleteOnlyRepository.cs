using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieDeleteOnlyRepository
    {
        Task<Movie?> GetById(int id);
        void Delete(Movie movie);
    }
}
