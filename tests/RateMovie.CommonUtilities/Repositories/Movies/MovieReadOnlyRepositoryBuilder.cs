using Moq;
using RateMovie.CommonUtilities.Entities;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.CommonUtilities.Repositories.Movies
{
    public class MovieReadOnlyRepositoryBuilder
    {
        private readonly Mock<IMovieReadOnlyRepository> _moq;

        public MovieReadOnlyRepositoryBuilder()
        {
            _moq = new Mock<IMovieReadOnlyRepository>();
        }

        public MovieReadOnlyRepositoryBuilder GetAll(User user, int? movieQuantity = null)
        {
            List<Movie> movies = MovieBuilder.BuildList(user, movieQuantity);

            _moq.Setup(movieReadOnly => movieReadOnly.GetAll(user.Id)).ReturnsAsync(movies);

            return this;
        }

        //public IMovieReadOnlyRepository GetById()
        //{

        //}

        public IMovieReadOnlyRepository Build()
        {
            return _moq.Object;
        }
    }
}
