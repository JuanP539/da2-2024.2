using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Out
{
    public class CreateMovieResponse
    {
        public Guid GUID { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
