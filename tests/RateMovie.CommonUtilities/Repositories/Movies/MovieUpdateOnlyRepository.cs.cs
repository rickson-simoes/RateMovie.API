using Moq;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;

namespace RateMovie.CommonUtilities.Repositories.Movies
{
    public class MovieUpdateOnlyRepository
    {
        private readonly Mock<IMovieUpdateOnlyRepository> _moq;

        public MovieUpdateOnlyRepository()
        {
            _moq = new Mock<IMovieUpdateOnlyRepository>();
        }

        public void GetById(Movie? movie = null)
        {
            if (movie is not null)
            {
                _moq.Setup(updateRepository => updateRepository.GetById(movie.Id, It.IsAny<int>())).ReturnsAsync(movie);
            }
        }

        public IMovieUpdateOnlyRepository Build()
        {
            return _moq.Object;
        }
    }
}
