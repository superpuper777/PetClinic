using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PetClinicDAL.DataHelpers.Base;
using PetClinicDAL.DbContext;
using PetClinicFacade.Interfaces;

namespace PetClinicDAL.DataHelpers
{
    public class UsersDataHelper : DataHelperBase, IUsersDataHelper
    {
        public async Task<List<string>> GetUsersEmailListAsync()
        {
            return await QueryAsync<PetClinicContext, List<string>>(db => db.Users.Select(u => u.Email).ToListAsync());
        }
    }
}
