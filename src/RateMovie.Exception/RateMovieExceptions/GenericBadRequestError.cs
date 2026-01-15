using System.Net;

namespace RateMovie.Exception.RateMovieExceptions
{
    public class GenericBadRequestError(string msg)  : RateMovieBaseException(msg)
    {
        public override HttpStatusCode ErrorStatusCode => HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
