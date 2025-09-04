using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Movies;
using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.Repositories.Movies
{
    internal class MovieWriteOnlyRepository : IMovieWriteOnlyRepository
    {
        private readonly RateMovieDBContext _rateMovieDBContext;
        private readonly IUnitOfWorkRepository _unitOfWork;
        public MovieWriteOnlyRepository(RateMovieDBContext rateMovieDBContext, IUnitOfWorkRepository unitOfWork)
        {
            _rateMovieDBContext = rateMovieDBContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Register(Movie movie)
        {
            await _rateMovieDBContext.Movies.AddAsync(movie);
            await _unitOfWork.Commit();
        }
    }
}
