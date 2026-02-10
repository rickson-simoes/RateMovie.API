using RateMovie.Communication.Enum;

namespace RateMovie.Communication.Responses.Movie
{
    public class ResponseShortMovieJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public byte Stars { get; set; }
        public MovieGenre Genre { get; set; }
    }
}
