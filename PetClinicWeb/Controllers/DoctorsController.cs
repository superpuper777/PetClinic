using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorsController : Controller
    {
        private readonly IDoctorsDataHelper _doctorsDataHelper;

        public DoctorsController(IDoctorsDataHelper doctorsDataHelper)
        {
            _doctorsDataHelper = doctorsDataHelper;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> List(DoctorFilterModel filterModel)
        {
            var doctorsList = await _doctorsDataHelper.GetListAsync(filterModel);
            return Json(doctorsList.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Save(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                await _doctorsDataHelper.AddAsync(model);
                return Json(new {success = true});
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task<JsonResult> Edit(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                await _doctorsDataHelper.EditAsync(model);
                return Json(new { success = true });
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task Delete(DoctorModel model)
        {
            await _doctorsDataHelper.DeleteAsync(model);
        }
    }
}