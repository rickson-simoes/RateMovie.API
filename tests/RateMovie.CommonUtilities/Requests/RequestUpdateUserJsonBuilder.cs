using Bogus;
using RateMovie.Communication.Requests.User;

namespace RateMovie.CommonUtilities.Requests
{
    public class RequestUpdateUserJsonBuilder
    {
        public static RequestUpdateUserJson Build()
        {
            return new Faker<RequestUpdateUserJson>()
                .CustomInstantiator(faker => new RequestUpdateUserJson(faker.Person.FullName));
        }
    }
}
