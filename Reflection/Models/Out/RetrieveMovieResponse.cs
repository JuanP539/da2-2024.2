using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Out
{
    public class RetrieveMovieResponse
    {
        public string Title { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public RetrieveMovieResponse() { }

        public RetrieveMovieResponse(Movie movie)
        {
            Title = movie.Title;
            Genres = movie.Genres;
        }
        public override bool Equals(object? obj)
        {
            return obj is RetrieveMovieResponse response &&
                   Title == response.Title;
        }
    }
}
