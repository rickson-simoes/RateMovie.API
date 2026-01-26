using Moq;
using RateMovie.Domain.Repositories.Users;

namespace RateMovie.CommonUtilities.Repositories.Users
{
    public class UserWriteOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var writeOnly = new Mock<IUserWriteOnlyRepository>();

            return writeOnly.Object;
        }
    }
}
