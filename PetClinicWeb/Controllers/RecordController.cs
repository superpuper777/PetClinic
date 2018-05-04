using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Mail;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;
using PetClinicWeb.Models.Record;
using PetClinicWeb.System.Extensions;

namespace PetClinicWeb.Controllers
{
    [Authorize(Roles = "Client")]
    public class RecordController : Controller
    {
        private readonly IServicesDataHelper _servicesDataHelper;
        private readonly IDoctorsDataHelper _doctorsDataHelper;
        private readonly IReceptionsDataHelper _receptionsDataHelper;

        public RecordController(IServicesDataHelper servicesDataHelper, IDoctorsDataHelper doctorsDataHelper, IReceptionsDataHelper receptionsDataHelper)
        {
            _servicesDataHelper = servicesDataHelper;
            _doctorsDataHelper = doctorsDataHelper;
            _receptionsDataHelper = receptionsDataHelper;
        }
        
        public async Task<ActionResult> Index()
        {
            var model = new RecordViewModel();
            await FillModel(model);

            return View(model);
        }

        public async Task<ActionResult> Submit(RecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identity = User.Identity as ClaimsIdentity;
                var idClaim = identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (idClaim != null)
                {
                    await _receptionsDataHelper.AddAsync(new ReceptionModel
                    {
                        Date = model.Date,
                        Discount = 0,
                        DoctorId = model.DoctorId,
                        ServiceId = model.ServiceId,
                        Time = model.Time,
                        PatientId = Int32.Parse(idClaim.Value)
                    });
                   
                    return View("Complete", model);
                }
            }

            await FillModel(model);

            return View("Index", model);
        }

        [HttpPost]
        public async Task<JsonResult> BusyTimeList(BusyTimeListFilterModel filterModel)
        {
            var busyTimeList = await _receptionsDataHelper.GetBusyTimeListOnDateAsync(filterModel);
            return Json(new
            {
                success = true,
                data = busyTimeList
            });
        }

        private async Task FillModel(RecordViewModel model)
        {
            var doctorsListTask = _doctorsDataHelper.GetListAsync(new DoctorFilterModel());
            var servicesListTask = _servicesDataHelper.GetListAsync(new ServiceFilterModel());

            await Task.WhenAll(doctorsListTask, servicesListTask);

            model.Login = User.Identity.Name;
            model.DoctorsList = doctorsListTask.Result.ToList().ToSelectListItems();
            model.ServicesList = servicesListTask.Result.ToList().ToSelectListItems();
        }
    }
}