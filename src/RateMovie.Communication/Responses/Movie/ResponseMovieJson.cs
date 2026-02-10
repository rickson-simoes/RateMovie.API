using RateMovie.Communication.Enum;

namespace RateMovie.Communication.Responses.Movie
{
    public class ResponseMovieJson
    {
        public string Name { get; set; } = "";
        public string? Comment { get; set; }
        public byte Stars { get; set; }
        public DateTime CreatedAt { get; set; }
        public MovieGenre Genre { get; set; }
    }
}
