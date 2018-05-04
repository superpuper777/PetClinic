using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetClinicFacade.Models;

namespace PetClinicWeb.Models.Schedulers
{
    public class SchedulersFilterViewModel
{
    public int SelectedDoctorId { get; set; }
    public int SelectedPatientId { get; set; }
    public int SelectedServiceId { get; set; }
    public List<DoctorModel> DoctorsList { get; set; }
    public List<PatientModel> PatientsList { get; set; }
    public List<ServiceModel> ServicesList { get; set; }
}
}