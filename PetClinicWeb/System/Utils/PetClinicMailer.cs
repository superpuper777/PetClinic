using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using PetClinicFacade.Models;
using PetClinicWeb.System.Interfaces;

namespace PetClinicWeb.System.Utils
{
    public class PetClinicMailer : IPetClinicMailer
    {
        private readonly string _login;
        private readonly string _password;
        private readonly string _emailFrom;

        public PetClinicMailer()
        {
            _login = ConfigurationManager.AppSettings["SmtpServerLogin"];
            _password = ConfigurationManager.AppSettings["SmtpServerPassword"];
            _emailFrom = ConfigurationManager.AppSettings["SmtpServerEmailFrom"];
        }

        public async Task<bool> SendAsync(List<string> emails, EmailModel model)
        {
            if (string.IsNullOrEmpty(_login) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(_emailFrom))
                throw new Exception("Не настроены параметры для рассылки");

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(_login, _password);

            var mailMessage = new MailMessage {From = new MailAddress(_emailFrom)};
            mailMessage.To.Add(string.Join(",", emails));
            mailMessage.Subject = model.Subject;
            mailMessage.Body = model.Body;

            await client.SendMailAsync(mailMessage);

            return true;
        }
    }
}