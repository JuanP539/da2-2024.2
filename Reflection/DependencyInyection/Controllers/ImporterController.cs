using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/importers")]
    public class ImporterController : Controller
    {
        private readonly IImporterLogic _importerLogic;

        public ImporterController(IImporterLogic importerLogic)
        {
            _importerLogic = importerLogic;
        }

        [HttpGet]
        public IActionResult ImportersName()
        {
            var availableImporters = _importerLogic.GetAllImporters();
            return Ok(availableImporters.Select(i => i.GetName()).ToList());
        }

        [HttpGet]
        public IActionResult Index2()
        {
            var availableImporters = _importerLogic.GetAllImporters();
            return Ok(availableImporters.Select(i => i.ImportMovie()).ToList());
        }
    }
}
