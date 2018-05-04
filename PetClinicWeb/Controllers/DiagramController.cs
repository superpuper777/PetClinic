using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;

namespace PetClinicWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiagramController : Controller
    {
        private readonly IDiagramDataHelper _diagramDataHelper;

        public DiagramController(IDiagramDataHelper diagramDataHelper)
        {
            _diagramDataHelper = diagramDataHelper;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _diagramDataHelper.GetDiagramDataAsync();
            return View(model);
        }
    }
}