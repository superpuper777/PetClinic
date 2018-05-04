using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetClinicWeb.Models.Admin
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [MinLength(5)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}