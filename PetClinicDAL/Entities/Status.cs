using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicDAL.Entities
{
    [Table("Statuses")]
    internal class Status
    {
        public Status()
        {
            Receptions = new List<Reception>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Reception> Receptions { get; set; }
    }
}