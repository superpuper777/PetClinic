using System;

namespace PetClinicFacade.Models
{
    public class DiscountModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Percent { get; set; }
    }
}