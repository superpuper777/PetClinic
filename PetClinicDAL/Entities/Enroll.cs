using System;

namespace PetClinicDAL.Entities
{
    internal class Enroll
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
    }
}