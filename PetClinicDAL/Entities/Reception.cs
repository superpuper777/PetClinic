using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicDAL.Entities
{
    [Table("Receptions")]
    internal class Reception
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? ServiceId { get; set; }
        public Service Service { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public int Discount { get; set; }
    }
}