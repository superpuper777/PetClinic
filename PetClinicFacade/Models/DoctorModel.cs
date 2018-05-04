using System.ComponentModel.DataAnnotations;

namespace PetClinicFacade.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialisation { get; set; }
    }
}