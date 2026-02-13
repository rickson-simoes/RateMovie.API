using Moq;
using RateMovie.Domain.Repositories.Users;

namespace RateMovie.CommonUtilities.Repositories.Users
{
    public class UserDeleteOnlyRepositoryBuilder
    {
        public static IUserDeleteOnlyRepository Build()
        {
            var moq = new Mock<IUserDeleteOnlyRepository>();

            return moq.Object;
        }
    }
}
