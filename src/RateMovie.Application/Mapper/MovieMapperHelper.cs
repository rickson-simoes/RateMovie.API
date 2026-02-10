using RateMovie.Communication.Requests.Movie;
using RateMovie.Communication.Responses.Movie;
using RateMovie.Domain.Entities;

namespace RateMovie.Application.Mapper
{
    public static class MovieMapperHelper
    {
        public static ResponseShortMovieJson? ToResponseShortMovieJson(this Movie movie)
        {
            return new ResponseShortMovieJson
            {
                Id = movie.Id,
                Name = movie.Name,
                Stars = movie.Stars,
                Genre = (Communication.Enum.MovieGenre)movie.Genre
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
               Genre = requestMovie.Genre
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
                UserId = userId
            };
        }

        public static void UpdateFromRequestMovieJson(this Movie movie, RequestMovieJson req)
        {
            movie.Name = req.Name;
            movie.Comment = req.Comment;
            movie.Stars = req.Stars;
            movie.Genre = (Domain.Enum.MovieGenre)req.Genre;            
        }
    }
}
