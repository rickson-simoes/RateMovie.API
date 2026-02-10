using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Users
{
    public interface IUserDeleteOnlyRepository
    {
        void Delete(User user);
    }
}
