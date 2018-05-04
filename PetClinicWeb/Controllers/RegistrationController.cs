using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;
using PetClinicWeb.Models.Registration;
using PetClinicWeb.System.Interfaces;
using PetClinicWeb.System.Models;

namespace PetClinicWeb.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationDataHelper _registrationDataHelper;
        private readonly IPasswordHelper _passwordHelper;

        public RegistrationController(IRegistrationDataHelper registrationDataHelper, IPasswordHelper passwordHelper)
        {
            _registrationDataHelper = registrationDataHelper;
            _passwordHelper = passwordHelper;
        }

        public ActionResult Index()
        {
            return View(new NewUserViewModel());
        }

        public async Task<ActionResult> Submit(NewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _registrationDataHelper.SubmitNewUser(new NewUserModel
                    {
                        Name = model.Name,
                        Owner = model.Owner,
                        Login = model.Login,
                        PasswordHash = _passwordHelper.Protect(model.Password, model.Login),
                        TypeOfPet = model.TypeOfPet,
                        TelephoneNumber = model.TelephoneNumber,
                        Sex = model.Sex
                    });

                    if (user != null)
                    {
                        var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddDays(1),
                            false, JsonConvert.SerializeObject(new UsrData
                            {
                                Id=user.Id, Role= user.Role
                           }));
                        var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View("Index", model);
        }
    }
}