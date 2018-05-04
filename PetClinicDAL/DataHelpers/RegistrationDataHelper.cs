using System;
using System.Data.Entity;
using System.Threading.Tasks;
using PetClinicDAL.DataHelpers.Base;
using PetClinicDAL.DbContext;
using PetClinicDAL.Entities;
using PetClinicDAL.Enums;
using PetClinicFacade.Interfaces;
using PetClinicFacade.Models;

namespace PetClinicDAL.DataHelpers
{
    public class RegistrationDataHelper : DataHelperBase, IRegistrationDataHelper
    {
        public async Task<CurrentUser> SubmitNewUser(NewUserModel model)
        {
            var user = await QueryAsync<PetClinicContext, User>(db => db.Users.FirstOrDefaultAsync(u => u.Email == model.Login));
            if (user != null)
                throw new Exception($"Пользователь c именем '{model.Login}' уже зарегистрирован");

            var newUserId = 0;

            await QueryAsync<PetClinicContext>(async db =>
            {
                var newUser = new User
                {
                    Email = model.Login,
                    Password = model.PasswordHash,
                    RoleId = (int)RoleType.Client,
                    Patient = new Patient
                    {
                        Name = model.Name,
                        Owner = model.Owner,
                        Sex = model.Sex,
                        TelephoneNumber = model.TelephoneNumber,
                        TypeOfPet = model.TypeOfPet
                    }
                };

                db.Users.Add(newUser);
                await db.SaveChangesAsync();

                newUserId = newUser.id;
            });

            return new CurrentUser
            {
                Id = newUserId,
                Login = model.Login,
                Role = Enum.GetName(typeof(RoleType), RoleType.Client)
            };
        }
    }
}