using System;

namespace PetClinicFacade.Models
{
    public class DiscountFilterModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Percent { get; set; }
    }
}