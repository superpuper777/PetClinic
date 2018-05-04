using System;
using System.Data.Entity;
using System.Threading.Tasks;
using PetClinicDAL.DataHelpers.Base;
using PetClinicDAL.DbContext;
using PetClinicDAL.Entities;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicDAL.DataHelpers
{
    public class AuthDataHelper : DataHelperBase, IAuthDataHelper
    {
        public async Task<CurrentUser> ValidateUserAsync(string login, string passwordHash)
        {
            var user = await QueryAsync<PetClinicContext, User>(
                db => db.Users.Include(t => t.Role).FirstOrDefaultAsync(u => u.Email == login && u.Password == passwordHash));

            if (user != null)
            {
                return new CurrentUser
                {
                    Id = user.id,
                    Login = user.Email,
                    Role = user.Role.Name
                };
            }

            throw new Exception("Неверный логин или пароль");
        }
    }
}