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
               .RuleFor(m => m.Name, faker => faker.Name.LastName())
               .RuleFor(m => m.Comment, faker => faker.Hacker.Phrase())
               .RuleFor(m => m.Stars, faker => faker.Random.Byte(1, 5))
               .RuleFor(m => m.Genre, faker => faker.Random.Enum<MovieGenre>())
               .RuleFor(m => m.CreatedAt, faker => faker.DateTimeReference.GetValueOrDefault(DateTime.UtcNow))
               .RuleFor(m => m.Id, faker => movieId != null ? movieId : 1)
               .RuleFor(m => m.UserId, user.Id);
        }

        public static List<Movie> BuildList(User user, int? movieQuantity = null)
        {
            List<Movie> movies = [];

            if (movieQuantity is not null)
            {
                for (var i = 0; i < movieQuantity; i++)
                {
                    movies.Add(Build(user, i+1));
                }
            }

            return movies;
        }
    }
}
