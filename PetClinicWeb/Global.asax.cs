using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using PetClinicWeb.App_Start;
using PetClinicWeb.System.Models;

namespace PetClinicWeb
{
    public class MvcApplication : HttpApplication
    {
        public override void Init()
        {
            base.AuthenticateRequest += OnAuthenticateRequest;
        }

        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void OnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    var decodedTicket = FormsAuthentication.Decrypt(cookie.Value);
                    var usrData = JsonConvert.DeserializeObject(decodedTicket?.UserData, typeof(UsrData)) as UsrData;
                    
                    var principal = new GenericPrincipal(HttpContext.Current.User.Identity, new[] { usrData?.Role });
                    var identity = principal.Identity as ClaimsIdentity;
                    identity?.AddClaim(new Claim(ClaimTypes.NameIdentifier, usrData?.Id.ToString()));
                    HttpContext.Current.User = principal;
                }
            }
        }
    }
}