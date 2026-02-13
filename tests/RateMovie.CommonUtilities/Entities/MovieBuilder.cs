using Bogus;
using RateMovie.Domain.Entities;
using RateMovie.Domain.Enum;

namespace RateMovie.CommonUtilities.Entities
{
    public class MovieBuilder
    {
        public static Movie Build(User user, int? movieId = null)
        {
            return new Faker<Movie>()
               .RuleFor(m => m.Name, faker => faker.Random.String())
               .RuleFor(m => m.Comment, faker => faker.Hacker.Phrase())
               .RuleFor(m => m.Stars, faker => faker.Random.Byte(1, 5))
               .RuleFor(m => m.Genre, faker => faker.Random.Enum<MovieGenre>())
               .RuleFor(m => m.CreatedAt, faker => faker.DateTimeReference.GetValueOrDefault(DateTime.UtcNow))
               .RuleFor(m => m.Id, faker => movieId != null ? movieId : faker.Random.Int())
               .RuleFor(m => m.UserId, user.Id);
        }
    }
}
