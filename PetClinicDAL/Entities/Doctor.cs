using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicDAL.Entities
{
    [Table("Doctors")]
    internal class Doctor
    {
        public Doctor()
        {
            Receptions = new List<Reception>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialisation { get; set; }
        public ICollection<Reception> Receptions { get; set; }
    }
}