using Bogus;
using RateMovie.Communication.Requests;

namespace Tests.CommonUtilities.Requests
{
    public class RequestAddUserJsonBuilder
    {
        public static RequestAddUserJson Build()
        {
            var request = new Faker<RequestAddUserJson>()
                .RuleFor(req => req.Name, faker => faker.Name.FirstName())
                .RuleFor(req => req.Email, (faker, req) => faker.Internet.Email(req.Name))
                .RuleFor(req => req.Password, faker => faker.Internet.Password(8, prefix: "1@Bb"));

            return request;
        }
    }
}
