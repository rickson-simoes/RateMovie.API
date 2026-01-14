using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Users
{
    public interface IUserReadOnlyRepository
    {
        Task<User?> GetByEmail(string email);

        Task<bool> EmailExists(string email);
    }
}
