using Moq;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.CommonUtilities.Repositories.Movies
{
    public class MovieDeleteOnlyRepositoryBuilder
    {
        public static IMovieDeleteOnlyRepository Build()
        {
            var moq = new Mock<IMovieDeleteOnlyRepository>();

            return moq.Object;
        }
    }
}
