using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieWriteOnlyRepository
    {
        Task Add(Movie movie);
    }
}
