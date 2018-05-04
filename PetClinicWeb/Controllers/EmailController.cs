using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net.Mvc;
using PetClinicFacade.Models;

namespace PetClinicWeb.Controllers
{
    public class EmailController : MailerBase
    {
        // GET: Email
        public EmailResult SendEmail(EmailModel model)
        {
            //To.Add(model.To);
            //From = model.From;
            Subject = model.Subject;
            return Email("SendEmail",model);
        } 
    }
}