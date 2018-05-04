using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IDoctorsDataHelper
    {
        Task<IEnumerable<DoctorModel>> GetListAsync(DoctorFilterModel filterModel);
        Task AddAsync(DoctorModel model);
        Task EditAsync(DoctorModel model);
        Task DeleteAsync(DoctorModel model);
    }
}