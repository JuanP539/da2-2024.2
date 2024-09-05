using DataAccess.Context;
using Domain;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _moviesContext;

        public MovieRepository(MovieContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public Movie GetMovieByTitle(string title)
        {
            return _moviesContext.Movies.First(m => m.Title == title);
        }

    }
}
