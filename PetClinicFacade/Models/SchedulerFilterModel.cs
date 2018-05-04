using System;


namespace PetClinicFacade.Models
{
    public class SchedulerFilterModel
    {
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public int? DoctorId { get; set; }
    public int? ServiceId { get; set; }
    public int? PatientId { get; set; }
    }
}
