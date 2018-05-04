using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IRegistrationDataHelper
    {
        Task<CurrentUser> SubmitNewUser(NewUserModel model);
    }
}