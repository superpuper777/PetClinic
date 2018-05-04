using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PetClinicDAL.DataHelpers.Base;
using PetClinicDAL.DbContext;
using PetClinicDAL.Entities;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicDAL.DataHelpers
{
    public class StatusesDataHelper : DataHelperBase, IStatusesDataHelper
    {
        public async Task<IEnumerable<ReceptionStatusModel>> GetListAsync()
        {
            var statuses = await QueryAsync<PetClinicContext, List<Status>>(db => db.Statuses.ToListAsync());

            return statuses.Select(d => new ReceptionStatusModel
            {
                Id = d.Id,
                Name = d.Name
            });
        }
    }
}
