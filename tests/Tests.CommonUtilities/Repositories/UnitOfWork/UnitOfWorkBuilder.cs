using Moq;
using RateMovie.Domain.Repositories.UnitOfWork;

namespace Tests.CommonUtilities.Repositories.UnitOfWork
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
