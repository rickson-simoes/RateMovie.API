namespace RateMovie.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorResponse { get; set; } = [];

        public ResponseErrorJson(string message)
        {
            ErrorResponse = [message];
        }

        public ResponseErrorJson(List<string> messages)
        {
            ErrorResponse = messages;
        }
    }
}
