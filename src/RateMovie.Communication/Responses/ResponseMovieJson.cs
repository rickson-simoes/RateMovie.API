namespace RateMovie.Communication.Responses
{
    public class ResponseMovieJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Comment { get; set; } = "";
        public byte Stars { get; set; }
    }
}
