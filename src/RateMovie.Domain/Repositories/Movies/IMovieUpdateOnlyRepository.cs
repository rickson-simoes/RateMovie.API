﻿using RateMovie.Domain.Entities;

namespace RateMovie.Domain.Repositories.Movies
{
    public interface IMovieUpdateOnlyRepository
    {
        Task<Movie?> GetById(int id);
        void Update(Movie movie);
    }
}
