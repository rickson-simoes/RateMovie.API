using System.Net;

namespace RateMovie.Exception.RateMovieExceptions
{
    public abstract class RateMovieBaseException : SystemException
    {
        public abstract HttpStatusCode ErrorStatusCode { get; }
        protected RateMovieBaseException(string message) : base(message) { }
        protected RateMovieBaseException() { }
        public abstract List<string> GetErrors();
    }
}
