using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Services
{
    public interface ILoggedUser
    {
        Task<User> Get();
    }
}
