using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicDAL.Entities
{
    [Table("Services")]
    internal class Service
    {
        public Service()
        {
            Receptions = new List<Reception>();
        }

        public int Id { get; set; }
        public string TypeOfServiceAndPr { get; set; }
        public string Amount { get; set; }
        public decimal Cost { get; set; }
        public ICollection<Reception> Receptions { get; set; }
    }
}