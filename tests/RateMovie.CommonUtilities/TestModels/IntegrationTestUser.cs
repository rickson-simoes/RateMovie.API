using RateMovie.Domain.Enum;

namespace RateMovie.CommonUtilities.TestModels
{
    internal record IntegrationTestUser(
        int Id,
        string Name,
        string Email,
        string Password,
        UserRole Role,
        string Token);
}
