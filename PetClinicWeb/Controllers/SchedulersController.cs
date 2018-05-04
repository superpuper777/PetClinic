using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;
using PetClinicWeb.Models.Receptions;
using PetClinicWeb.Models.Schedulers;

namespace PetClinicWeb.Controllers
{
    public class SchedulersController : Controller
    {
        private readonly IDoctorsDataHelper _doctorsDataHelper;
        private readonly IPatientsDataHelper _patientsDataHelper;
        private readonly IReceptionsDataHelper _receptionsDataHelper;
        private readonly IServicesDataHelper _servicesDataHelper;
        private readonly IStatusesDataHelper _statusesDataHelper;

        public SchedulersController(IReceptionsDataHelper receptionsDataHelper,
            IDoctorsDataHelper doctorsDataHelper, IServicesDataHelper servicesDataHelper,
            IPatientsDataHelper patientsDataHelper, IStatusesDataHelper statusesDataHelper)
        {
            _receptionsDataHelper = receptionsDataHelper;
            _doctorsDataHelper = doctorsDataHelper;
            _servicesDataHelper = servicesDataHelper;
            _patientsDataHelper = patientsDataHelper;
            _statusesDataHelper = statusesDataHelper;
        }

        public async Task<ActionResult> Index()
        {
            var doctorsListTask = _doctorsDataHelper.GetListAsync(new DoctorFilterModel());
            var patientsListTask = _patientsDataHelper.GetListAsync(new PatientFilterModel());
            var servicesListTask = _servicesDataHelper.GetListAsync(new ServiceFilterModel());
            var statusesListAsync = _statusesDataHelper.GetListAsync();

            await Task.WhenAll(doctorsListTask, patientsListTask, servicesListTask, statusesListAsync);

            var doctorsList = new List<DoctorModel>
            {
                new DoctorModel
                {
                    Name = string.Empty
                }
            };
            doctorsList.AddRange(doctorsListTask.Result.ToList());

            var patientsList = new List<PatientModel>
            {
                new PatientModel
                {
                    Owner = string.Empty
                }
            };
            patientsList.AddRange(patientsListTask.Result.ToList());

            var servicesList = new List<ServiceModel>
            {
                new ServiceModel
                {
                    TypeOfServiceAndPr = string.Empty
                }
            };
            servicesList.AddRange(servicesListTask.Result.ToList());

            var statusesList = new List<ReceptionStatusModel>
            {
                new ReceptionStatusModel
                {
                    Name = string.Empty
                }
            };
            statusesList.AddRange(statusesListAsync.Result.ToList());

            var model = new ReceptionFilterViewModel
            {
                DoctorsList = doctorsList,
                PatientsList = patientsList,
                ServicesList = servicesList,
                StatusesList = statusesList
            };
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> List(ReceptionFilterModel filterModel)
        {
            var receptionsList = await _receptionsDataHelper.GetListAsync(filterModel);
            return Json(receptionsList.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Save(ReceptionModel model)
        {
            if (ModelState.IsValid)
            {
                await _receptionsDataHelper.AddAsync(model);
                return Json(new { success = true });
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task<JsonResult> Edit(ReceptionModel model)
        {
            if (ModelState.IsValid)
            {
                await _receptionsDataHelper.EditAsync(model);
                return Json(new { success = true });
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task Delete(ReceptionModel model)
        {
            await _receptionsDataHelper.DeleteAsync(model);
        }

    }
}