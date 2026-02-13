using Moq;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.CommonUtilities.Repositories.Movies
{
    public class MovieWriteOnlyRepositoryBuilder
    {
        public static IMovieWriteOnlyRepository Build()
        {
            var moq = new Mock<IMovieWriteOnlyRepository>();

            return moq.Object;
        }
    }
}
