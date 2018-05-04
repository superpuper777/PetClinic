using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly IServicesDataHelper _servicesDataHelper;

        public ServicesController(IServicesDataHelper servicesDataHelper)
        {
            _servicesDataHelper = servicesDataHelper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> List(ServiceFilterModel filterModel)
        {
            var doctorsList = await _servicesDataHelper.GetListAsync(filterModel);
            return Json(doctorsList.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Save(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                await _servicesDataHelper.AddAsync(model);
                return Json(new { success = true });
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task<JsonResult> Edit(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                await _servicesDataHelper.EditAsync(model);
                return Json(new { success = true });
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task Delete(ServiceModel model)
        {
            await _servicesDataHelper.DeleteAsync(model);
        }
    }
}