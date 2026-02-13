using Moq;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.CommonUtilities.Repositories.Movies
{
    public class MovieDeleteOnlyRepository
    {
        public static IMovieDeleteOnlyRepository Build()
        {
            var moq = new Mock<IMovieDeleteOnlyRepository>();

            return moq.Object;
        }
    }
}
