using Microsoft.EntityFrameworkCore;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Repositories.Users;
using RateMovie.Infrastructure.DataAccess;

namespace RateMovie.Infrastructure.Repositories.Users
{
    internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository, IUserDeleteOnlyRepository
    {
        private readonly RateMovieDBContext _dbContext;

        public UserRepository(RateMovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public void Delete(User user)
        {
            _dbContext.Users.Remove(user);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email == email);
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email == email);

            return user;
        }
    }
}
