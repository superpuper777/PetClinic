using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetClinicWeb.Models.Registration
{
    public class NewUserViewModel
    {
        [Required]
        [DisplayName("ФИО")]
        public string Owner { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Телефон")]
        public string TelephoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        [DisplayName("Повторите пароль")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Кличка")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Тип")]
        public string TypeOfPet { get; set; }

        [Required]
        [DisplayName("Пол")]
        public string Sex { get; set; }
        

    }
}