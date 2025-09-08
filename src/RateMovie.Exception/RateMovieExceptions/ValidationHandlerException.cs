using System.Net;

namespace RateMovie.Exception.RateMovieExceptions
{
    public class ValidationHandlerException : RateMovieBaseException
    {
        private readonly List<string> _validationErrorMessages;

        public override HttpStatusCode ErrorStatusCode => HttpStatusCode.BadRequest;

        public ValidationHandlerException(List<string> validationErrorMessages)
        {
            _validationErrorMessages = validationErrorMessages;
        }

        public override List<string> GetErrors()
        {
            return _validationErrorMessages;
        }
    }
}
