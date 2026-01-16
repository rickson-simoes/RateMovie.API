using RateMovie.Communication.Requests;
using RateMovie.Communication.Responses;
using RateMovie.Domain.Entities;

namespace RateMovie.Application.Mapper
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

        public static ResponseMovieJson ToResponseMovieJson(this Movie movie)
        {
            return new ResponseMovieJson
            {
                Name = movie.Name,
                Comment = movie.Comment,
                Stars = movie.Stars,
                Genre = (Communication.Enum.MovieGenre)movie.Genre,
                CreatedAt = movie.CreatedAt,
            };
        }

        public static ResponseMovieJson ToResponseMovieJson(this RequestMovieJson requestMovie)
        {
            return new ResponseMovieJson
            {
               Name = requestMovie.Name,
               Comment = requestMovie.Comment,
               Stars = requestMovie.Stars,
               Genre = requestMovie.Genre,
               CreatedAt = requestMovie.CreatedAt,
            };
        }

        public static Movie ToMovieEntity(this ResponseMovieJson responseMovie, int userId)
        {
            return new Movie
            {
                Name = responseMovie.Name,
                Comment = responseMovie.Comment,
                Stars = responseMovie.Stars,
                Genre = (Domain.Enum.MovieGenre)responseMovie.Genre,
                CreatedAt = responseMovie.CreatedAt,
                UserId = userId
            };
        }

        public static Movie ToMovieEntity(this RequestMovieJson requestMovie, int userId)
        {
            return new Movie
            {
                Name = requestMovie.Name,
                Comment = requestMovie.Comment,
                Stars = requestMovie.Stars,
                Genre = (Domain.Enum.MovieGenre)requestMovie.Genre,
                CreatedAt = requestMovie.CreatedAt,
                UserId = userId
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
