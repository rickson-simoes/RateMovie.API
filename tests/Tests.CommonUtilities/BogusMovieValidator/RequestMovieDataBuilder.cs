using Bogus;
using RateMovie.Communication.Requests;

namespace Tests.CommonUtilities.BogusMovieValidator
{
    public class RequestMovieDataBuilder
    {
        public RequestMovieJson Build()
        {
            var fakeRequest = new Faker<RequestMovieJson>()
                .RuleFor(req => req.Name, f => f.Random.Word())
                .RuleFor(req => req.Comment, f => f.Random.Words(count : 5))
                .RuleFor(req => req.Stars, f => f.Random.Byte(1, 5));

            return fakeRequest;
        }
    }
}
