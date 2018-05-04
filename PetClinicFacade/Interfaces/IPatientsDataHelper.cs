using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IPatientsDataHelper
    {
        Task<IEnumerable<PatientModel>> GetListAsync(PatientFilterModel filterModel);
        Task AddAsync(PatientModel model);
        Task EditAsync(PatientModel model);
        Task DeleteAsync(PatientModel model);
    }
}