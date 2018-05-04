using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IAuthDataHelper
    {
        Task<CurrentUser> ValidateUserAsync(string login, string passwordHash);
    }
}