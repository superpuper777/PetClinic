using PetClinicFacade.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PetClinicFacade.Interfaces;
using PetClinicWeb.System.Interfaces;

namespace PetClinicWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SendMessController : Controller
    {
        private readonly IUsersDataHelper _usersDataHelper;
        private readonly IPetClinicMailer _mailer;

        public SendMessController(IUsersDataHelper usersDataHelper, IPetClinicMailer mailer)
        {
            _usersDataHelper = usersDataHelper;
            _mailer = mailer;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                var emailList = await _usersDataHelper.GetUsersEmailListAsync();

                try
                {
                    await _mailer.SendAsync(emailList, model);

                    return RedirectToAction("Success");
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                    return View(model);
                }
            }
            return View(model);

        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}