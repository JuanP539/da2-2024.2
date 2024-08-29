using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.In
{
    public class CreateMovieRequest
    {
        public string Title { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
