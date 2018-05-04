using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IReceptionsDataHelper
    {
        Task<IEnumerable<ReceptionModel>> GetListAsync(ReceptionFilterModel filterModel);
        Task AddAsync(ReceptionModel model);
        Task EditAsync(ReceptionModel model);
        Task DeleteAsync(ReceptionModel model);
        Task<List<string>> GetBusyTimeListOnDateAsync(BusyTimeListFilterModel model);
    }
}