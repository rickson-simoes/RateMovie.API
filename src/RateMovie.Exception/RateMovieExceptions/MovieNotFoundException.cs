using System.Net;

namespace RateMovie.Exception.RateMovieExceptions
{
    public class MovieNotFoundException : RateMovieBaseException
    {
        public override HttpStatusCode ErrorStatusCode => HttpStatusCode.NotFound;
        public MovieNotFoundException(string message) : base(message) { }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
