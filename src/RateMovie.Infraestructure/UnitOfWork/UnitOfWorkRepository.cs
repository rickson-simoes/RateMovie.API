using RateMovie.Domain.Repositories.UnitOfWork;
using RateMovie.Infraestructure.DataAccess;

namespace RateMovie.Infraestructure.UnitOfWork
{
    internal class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly RateMovieDBContext _rateMovieDBContext;

        public UnitOfWorkRepository(RateMovieDBContext rateMovieDBContext)
        {
            _rateMovieDBContext = rateMovieDBContext;
        }
        public async Task Commit()
        {
            await _rateMovieDBContext.SaveChangesAsync();
        }
    }
}
