using Bogus;
using RateMovie.Communication.Requests;

namespace RateMovie.CommonUtilities.Requests
{
    public class RequestLoginJsonBuilder
    {
        public static RequestLoginJson Build(string? email = null)
        {
            var faker = new Faker();

            return new RequestLoginJson(
                email ?? faker.Internet.Email(),
                faker.Internet.Password(8, prefix: "1@Bb"));
        }
    }
}
