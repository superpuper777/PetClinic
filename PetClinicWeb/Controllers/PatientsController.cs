using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PatientsController : Controller
    {
        private readonly IPatientsDataHelper _patientsDataHelper;

        public PatientsController(IPatientsDataHelper patientsDataHelper)
        {
            _patientsDataHelper = patientsDataHelper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> List(PatientFilterModel filterModel)
        {
            var doctorsList = await _patientsDataHelper.GetListAsync(filterModel);
            return Json(doctorsList.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Save(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                await _patientsDataHelper.AddAsync(model);
                return Json(new {success = true});
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task<JsonResult> Edit(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                await _patientsDataHelper.EditAsync(model);
                return Json(new {success = true});
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task Delete(PatientModel model)
        {
            await _patientsDataHelper.DeleteAsync(model);
        }
    }
}