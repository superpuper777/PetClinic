using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicDAL.Entities
{
    [Table("Patients")]
    internal class Patient
    {
        public Patient()
        {
            Receptions = new List<Reception>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeOfPet { get; set; }
        public string Sex { get; set; }
        public string Owner { get; set; }
        public string TelephoneNumber { get; set; }
        public ICollection<Reception> Receptions { get; set; }
        public ICollection<User> User { get; set; }
    }
}