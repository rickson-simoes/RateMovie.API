using RateMovie.Communication.Enum;

namespace RateMovie.Communication.Responses.User
{
    public record ResponseGetAllUserDataJson(int id, string name, string email, UserRole role);
}
