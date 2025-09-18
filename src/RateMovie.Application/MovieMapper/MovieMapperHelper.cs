using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;

namespace RateMovie.Application.MovieMapper
{
    public static class MovieMapperHelper
    {
        public static ResponseShortMovieJson? ToResponseShortMovieJson(this Movie movie)
        {
            if (movie == null)
                return null;

            return new ResponseShortMovieJson
            {
                Id = movie.Id,
                Name = movie.Name,
                Stars = movie.Stars,
            };
        }

        public static ResponseMovieJson ToResponseMovieJson(this Movie requestMovie)
        {
            return new ResponseMovieJson
            {
                Name = requestMovie.Name,
                Comment = requestMovie.Comment,
                Stars = requestMovie.Stars,
            };
        }

        public static ResponseMovieJson ToResponseMovieJson(this RequestMovieJson requestMovie)
        {
            return new ResponseMovieJson
            {
               Name = requestMovie.Name,
               Comment = requestMovie.Comment,
               Stars = requestMovie.Stars,
            };
        }

        public static Movie ToMovieEntity(this ResponseMovieJson responseMovie)
        {
            return new Movie
            {
                Name = responseMovie.Name,
                Comment = responseMovie.Comment,
                Stars = responseMovie.Stars
            };
        }

        public static void GetRequestMovieData(this Movie movie, RequestMovieJson req)
        {
            movie.Name = req.Name;
            movie.Comment = req.Comment;
            movie.Stars = req.Stars;
        }
    }
}
