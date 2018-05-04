using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicWeb.System.Interfaces
{
    public interface IPetClinicMailer
    {
        Task<bool> SendAsync(List<string> emails, EmailModel model);
    }
}