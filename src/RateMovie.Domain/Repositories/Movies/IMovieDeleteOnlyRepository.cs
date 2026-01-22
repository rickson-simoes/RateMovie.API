using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieDeleteOnlyRepository
    {
        void Delete(Movie movie);
    }
}
