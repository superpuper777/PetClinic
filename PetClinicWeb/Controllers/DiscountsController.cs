using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicWeb.Controllers
{
    public class DiscountsController : Controller
    {
        private readonly IDiscountsDataHelper _discountsDataHelper;

        public DiscountsController(IDiscountsDataHelper discountsDataHelper)
        {
            _discountsDataHelper = discountsDataHelper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> List(DiscountFilterModel filterModel)
        {
            var discountsList = await _discountsDataHelper.GetListAsync(filterModel);
            return Json(discountsList.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Save(DiscountModel model)
        {
            if (ModelState.IsValid)
            {
                var id = await _discountsDataHelper.AddAsync(model);
                return Json(new {success = true, Id = id });
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task<JsonResult> Edit(DiscountModel model)
        {
            if (ModelState.IsValid)
            {
                await _discountsDataHelper.EditAsync(model);
                return Json(new {success = true});
            }

            return Json(new
            {
                success = false,
                message = "Неверно заполены поля"
            });
        }

        [HttpPost]
        public async Task Delete(DiscountModel model)
        {
            await _discountsDataHelper.DeleteAsync(model);
        }
    }
}