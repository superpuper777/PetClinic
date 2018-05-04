namespace PetClinicFacade.Models
{
    public class NewUserModel
    {
        public string Owner { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string TelephoneNumber { get; set; }
        public string Name { get; set; }
        public string TypeOfPet { get; set; }
        public string Sex { get; set; }
    }
}