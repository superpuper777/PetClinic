using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PetClinicFacade.Models;

namespace PetClinicWeb.System.Extensions
{
    public static class DoctorsListExtensions
    {
        public static List<SelectListItem> ToSelectListItems(this List<DoctorModel> list)
        {
            var result = new List<SelectListItem> {new SelectListItem()};
            result.AddRange(list.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString(),
            }));
            return result;
        }
    }
}