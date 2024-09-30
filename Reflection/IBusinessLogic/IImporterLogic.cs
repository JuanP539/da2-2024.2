using IImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IImporterLogic
    {
        List<ImporterInterface> GetAllImporters();
    }
}
