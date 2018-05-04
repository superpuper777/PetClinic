using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAL.Entities
{
    [Table("Schedules")]
    internal class Scheduler
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? ServiceId { get; set; }
        public Service Service { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
