using Domain;
using IImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVImporters
{
    public class CSVImporter : ImporterInterface
    {
        public string GetName()
        {
            return "CSV Importer";
        }

        public List<Movie> ImportMovie()
        {
            // Harcodeado - Aca deberia leer el archivo CSV de verdad
            return new List<Movie> { new Movie {Title="chuek csv" }, new Movie {Title="avatar csv" } };
        }
    }
}
