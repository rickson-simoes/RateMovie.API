using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
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

        public static ResponseAddUserJson ResponseAddUserJsonToUser(this User req, string token)
        {
            return new ResponseAddUserJson
            {
                Name = req.Name,
                Email = req.Email,
                Token = token
            };
        }
    }
}
