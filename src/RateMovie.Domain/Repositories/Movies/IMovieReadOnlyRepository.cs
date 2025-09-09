using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieReadOnlyRepository
    {
        Task<List<Movie>> GetAll();
    }
}
