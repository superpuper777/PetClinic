using System.ComponentModel.DataAnnotations;

namespace PetClinicFacade.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TypeOfPet { get; set; }

        public string Sex { get; set; }

        [Required]
        public string Owner { get; set; }

        public string TelephoneNumber { get; set; }
    }
}