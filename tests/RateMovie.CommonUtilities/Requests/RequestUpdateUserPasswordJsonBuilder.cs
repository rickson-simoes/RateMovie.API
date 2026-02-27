using Bogus;
using RateMovie.Communication.Requests.User;

namespace RateMovie.CommonUtilities.Requests
{
    public class RequestUpdateUserPasswordJsonBuilder
    {
        public static RequestUpdateUserPasswordJson Build()
        {
            return new Faker<RequestUpdateUserPasswordJson>()
                .CustomInstantiator(faker => new RequestUpdateUserPasswordJson(faker.Internet.Password(length: 10, prefix: "1aA!")));
        }
    }
}
