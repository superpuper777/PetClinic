using System.Collections.Generic;
using PetClinicFacade.Models;

namespace PetClinicWeb.Models.Receptions
{
    public class ReceptionFilterViewModel
    {
        public int SelectedDoctorId { get; set; }
        public int SelectedPatientId { get; set; }
        public int SelectedServiceId { get; set; }
        public List<DoctorModel> DoctorsList { get; set; }
        public List<PatientModel> PatientsList { get; set; }
        public List<ServiceModel> ServicesList { get; set; }
        public List<ReceptionStatusModel> StatusesList { get; set; }
    }
}