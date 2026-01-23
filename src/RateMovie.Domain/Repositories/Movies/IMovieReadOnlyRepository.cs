using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieReadOnlyRepository
    {
        Task<List<Movie>> GetAll(int userId);
        Task<List<Movie>> GetAll(byte? stars);
        Task<Movie?> GetById(int id);
    }
}
