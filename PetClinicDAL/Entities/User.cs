namespace PetClinicDAL.Entities
{
    internal class User
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}