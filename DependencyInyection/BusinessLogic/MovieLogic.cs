using Domain;
using IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MovieLogic : IMovieLogic
    {
        public Movie CreateMovie(Movie movie)
        {
            Console.WriteLine("Creating movie!");
            return movie;
        }

        public Movie GetMovieByTitle(string title)
        {//Metodo MUY mejorable (viola Clean Code por todos lados)
            string[] movies = { "Shrek", "Harry Potter", "Avengers: Endgame", "Avatar" };
            List<Movie> listMovies = (from movie in movies
                      where movie.ToLower().Equals(title.ToLower())
                      select movie).Select(s => new Movie {Title = title }).ToList();
            if (listMovies.Count == 0) return null;
            return listMovies[0];
        }

        public List<Movie> GetMoviesByPostix(string postfix)
        {

            return new List<Movie>()
            {
                new Movie()
                {
                    Title = "The " + postfix,
                    Genres = new List<string>()
                }
            };
        }
    }
}
