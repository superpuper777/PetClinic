using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface ISchedulersDataHelper
    {
        Task<IEnumerable<SchedulerModel>> GetListAsync(SchedulerFilterModel filterModel);
    }
}
