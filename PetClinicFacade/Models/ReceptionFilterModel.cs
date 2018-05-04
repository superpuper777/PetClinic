using System;

namespace PetClinicFacade.Models
{
    public class ReceptionFilterModel
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int? DoctorId { get; set; }
        public int? ServiceId { get; set; }
        public int? PatientId { get; set; }
        public int? StatusId { get; set; }
        public int Discount { get; set; }
    }
}