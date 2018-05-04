using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IStatusesDataHelper
    {
        Task<IEnumerable<ReceptionStatusModel>> GetListAsync();
    }
}
