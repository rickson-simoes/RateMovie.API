using Bogus;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Enum;

namespace Tests.CommonUtilities.Entities
{
    public class UserBuilder
    {
        public static User Build(UserRole? role = UserRole.Member)
        {
            return new Faker<User>()
                .RuleFor(u => u.Name, faker => faker.Name.FirstName())
                .RuleFor(u => u.Email, (faker, u) => faker.Internet.Email(u.Name))
                .RuleFor(u => u.Password, faker => faker.Internet.Password(8, prefix: "1@Bb"))
                .RuleFor(u => u.Role, role);
        }
    }
}
