using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RateMovie.Communication.Responses;
using RateMovie.Exception.RateMovieExceptions;

namespace RateMovie.Api.Filters
{
    public class RateMovieExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is RateMovieBaseException rateMovieBaseException)
            {
                ThrowRateMovieExceptionHandler(context, rateMovieBaseException);
            } 
            else
            {
                ThrowUnknownErrorException(context);
            }
        }

        public void ThrowRateMovieExceptionHandler(ExceptionContext context, RateMovieBaseException rateMovieBaseException)
        {
            ResponseErrorJson responseErrors = new ResponseErrorJson(rateMovieBaseException.GetErrors());

            context.HttpContext.Response.StatusCode = (int)rateMovieBaseException.ErrorStatusCode;
            context.Result = new ObjectResult(responseErrors);
        }

        public void ThrowUnknownErrorException(ExceptionContext context)
        {
            ResponseErrorJson responseErrors = new ResponseErrorJson("Unkown error");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(responseErrors);
        }
    }
}
