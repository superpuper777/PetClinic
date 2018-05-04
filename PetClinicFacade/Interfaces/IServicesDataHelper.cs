using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IServicesDataHelper
    {
        Task<IEnumerable<ServiceModel>> GetListAsync(ServiceFilterModel filterModel);
        Task AddAsync(ServiceModel model);
        Task EditAsync(ServiceModel model);
        Task DeleteAsync(ServiceModel model);
    }
}