using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PetClinicWeb.Models.Record
{
    public class RecordViewModel
    {
        public string Login { get; set; }

        [Required]
        [DisplayName("Услуга")]
        public int ServiceId { get; set; }

        [Required]
        [DisplayName("Врач")]
        public int DoctorId { get; set; }

        [Required]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Время")]
        public string Time { get; set; }

        public List<SelectListItem> DoctorsList { get; set; }
        public List<SelectListItem> ServicesList { get; set; }
    }
}