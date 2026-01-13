using RateMovie.Domain.Enum;

namespace RateMovie.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Comment { get; set; }
        public byte Stars { get; set; }
        public DateTime CreatedAt { get; set; }
        public MovieGenre Genre { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
