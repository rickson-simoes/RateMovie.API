using RateMovie.Communication.Requests;
using RateMovie.Domain.Entities;

namespace RateMovie.Application.Mapper
{
    public static class UserMapperHelper
    {
        public static User RequestAddUserJsonToUser(this RequestAddUserJson req)
        {
            return new User
            {
                Name = req.Name,
                Email = req.Email,
                Password = req.Password
            };
        }
    }
}
