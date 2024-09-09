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
            try
            {
                return _moviesContext.Movies.First(m => m.Title == title);
            }
            catch (InvalidOperationException) 
            {
                throw new InvalidOperationException("Bad");
            }
        }

    }
}
