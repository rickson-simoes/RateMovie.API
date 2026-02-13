using Moq;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Services;

namespace RateMovie.CommonUtilities.Services
{
    public class LoggedUserBuilder
    {
        public static ILoggedUser Build(User user)
        {
            var moq = new Mock<ILoggedUser>();

            moq.Setup(loggedUser => loggedUser.Get()).ReturnsAsync(user);

            return moq.Object;
        }
    }
}
