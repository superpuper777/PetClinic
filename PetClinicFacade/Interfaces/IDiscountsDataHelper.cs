using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinicFacade.Models;

namespace PetClinicFacade.Interfaces
{
    public interface IDiscountsDataHelper
    {
        Task<IEnumerable<DiscountModel>> GetListAsync(DiscountFilterModel filterModel);
        Task<int> AddAsync(DiscountModel model);
        Task EditAsync(DiscountModel model);
        Task DeleteAsync(DiscountModel model);
    }
}