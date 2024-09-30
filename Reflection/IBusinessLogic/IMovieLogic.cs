using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IMovieLogic
    {
        List<Movie> GetMoviesByPostix(string postfix);
        Movie GetMovieByTitle(string title);
        Movie CreateMovie(Movie movie);

    }
}
