using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinicFacade.Interfaces
{
    public interface IUsersDataHelper
    {
        Task<List<string>> GetUsersEmailListAsync();
    }
}