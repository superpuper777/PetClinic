using System;

namespace PetClinicDAL.Entities
{
    internal class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Percent { get; set; }
    }
}