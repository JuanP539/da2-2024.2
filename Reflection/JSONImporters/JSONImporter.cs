using Domain;
using IImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONImporters
{
    public class JSONImporter : ImporterInterface
    {
        public string GetName()
        {
            return "JSON Importer";
        }

        public List<Movie> ImportMovie()
        {
            // Harcodeado - Aca deberia leer el archivo CSV de verdad
            return new List<Movie> { new Movie { Title = "chuek json" }, new Movie { Title = "avatar json" } };
        }
    }
}
