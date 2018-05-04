using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using PetClinicFacade.Interfaces;
using PetClinicWeb.Models.Admin;
using System.Web;
using Newtonsoft.Json;
using PetClinicWeb.System.Interfaces;
using PetClinicWeb.System.Models;

namespace PetClinicWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthDataHelper _authDataHelper;
        private readonly IPasswordHelper _passwordHelper;

        public AuthController(IAuthDataHelper authDataHelper, IPasswordHelper passwordHelper)
        {
            _authDataHelper = authDataHelper;
            _passwordHelper = passwordHelper;
        }
        
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _authDataHelper.ValidateUserAsync(model.Login, _passwordHelper.Protect(model.Password, model.Login));
                    var ticket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddDays(1),
                        false,
                        JsonConvert.SerializeObject(new UsrData
                        {
                            Id = user.Id,
                            Role = user.Role
                        }));
                    var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View("Index", model);
                }
            }
            else
            {
                return View("Index", model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}