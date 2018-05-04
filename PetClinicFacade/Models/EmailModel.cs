using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetClinicFacade.Models
{
    public class EmailModel
    {
        [Required]
        [DisplayName("Тема")]
        public string Subject { get; set; }

        [Required]
        [DisplayName("Сообщение")]
        public string Body { get; set; }
    }
}