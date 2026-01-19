using Moq;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Users;

namespace Tests.CommonUtilities.Repositories.Users
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRepository> _userReadOnlyRepository;

        public UserReadOnlyRepositoryBuilder()
        {
            _userReadOnlyRepository = new Mock<IUserReadOnlyRepository>();
        }

        public void EmailExists(string email)
        {
            _userReadOnlyRepository.Setup(repo => repo.EmailExists(email)).ReturnsAsync(true);
        }

        public void GetByEmail(User user)
        {
            _userReadOnlyRepository.Setup(repo => repo.GetByEmail(user.Email)).ReturnsAsync(user);
        }

        public IUserReadOnlyRepository Build()
        {
            return _userReadOnlyRepository.Object;
        }
    }
}
