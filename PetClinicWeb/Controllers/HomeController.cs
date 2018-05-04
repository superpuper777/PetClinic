using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;

namespace PetClinicWeb.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> ServicesInf()
        {
            return View();
        } 

    }
}