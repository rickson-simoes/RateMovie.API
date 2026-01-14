using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Users
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(User user);
    }
}
