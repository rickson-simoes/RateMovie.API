using Moq;
using RateMovie.Domain.Repositories.UnitOfWork;

namespace RateMovie.CommonUtilities.Repositories.UnitOfWork
{
    public static class UnitOfWorkBuilder
    {
        public static IUnitOfWorkRepository Build()
        {
            var unitOfWork = new Mock<IUnitOfWorkRepository>();

            return unitOfWork.Object;
        }
    }
}
