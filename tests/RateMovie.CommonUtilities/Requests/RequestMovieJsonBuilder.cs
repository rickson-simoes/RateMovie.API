using Bogus;
using RateMovie.Communication.Requests;
using RateMovie.Communication.Enum;

namespace RateMovie.CommonUtilities.Requests
{
    public class RequestMovieJsonBuilder
    {
        public static RequestMovieJson Build()
        {
            return new Faker<RequestMovieJson>()
                .RuleFor(req => req.Name, f => f.Random.Word())
                .RuleFor(req => req.Comment, f => f.Random.Words(count: 5))
                .RuleFor(req => req.Stars, f => f.Random.Byte(1, 5))
                .RuleFor(req => req.Genre, f => f.PickRandom<MovieGenre>());
        }
    }
}
