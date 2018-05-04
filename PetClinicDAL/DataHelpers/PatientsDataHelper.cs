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
    public class PatientsDataHelper : DataHelperBase, IPatientsDataHelper
    {
        public async Task<IEnumerable<PatientModel>> GetListAsync(PatientFilterModel filterModel)
        {
            var patients = await QueryAsync<PetClinicContext, List<Patient>>(db =>
            {
                var patientsQuery = db.Patients.Select(p => p);
                if (!string.IsNullOrEmpty(filterModel.Name))
                    patientsQuery = patientsQuery.Where(p => p.Name.Contains(filterModel.Name));
                if (!string.IsNullOrEmpty(filterModel.Owner))
                    patientsQuery = patientsQuery.Where(p => p.Owner.Contains(filterModel.Owner));
                if (!string.IsNullOrEmpty(filterModel.Sex))
                    patientsQuery = patientsQuery.Where(p => p.Sex.Contains(filterModel.Sex));
                if (!string.IsNullOrEmpty(filterModel.TelephoneNumber))
                    patientsQuery = patientsQuery.Where(p => p.TelephoneNumber.Contains(filterModel.TelephoneNumber));
                if (!string.IsNullOrEmpty(filterModel.TypeOfPet))
                    patientsQuery = patientsQuery.Where(p => p.TypeOfPet.Contains(filterModel.TypeOfPet));
                return patientsQuery.ToListAsync();
            });

            return patients.Select(p => new PatientModel
            {
                Id = p.Id,
                Name = p.Name,
                Owner = p.Owner,
                Sex = p.Sex,
                TelephoneNumber = p.TelephoneNumber,
                TypeOfPet = p.TypeOfPet
            });
        }

        public async Task AddAsync(PatientModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                db.Patients.Add(new Patient
                {
                    Id = model.Id,
                    Name = model.Name,
                    Owner = model.Owner,
                    Sex = model.Sex,
                    TelephoneNumber = model.TelephoneNumber,
                    TypeOfPet = model.TypeOfPet
                });
                await db.SaveChangesAsync();
            });
        }

        public async Task EditAsync(PatientModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var edit = await db.Patients.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (edit != null)
                {
                    edit.Id = model.Id;
                    edit.Name = model.Name;
                    edit.Owner = model.Owner;
                    edit.Sex = model.Sex;
                    edit.TelephoneNumber = model.TelephoneNumber;
                    edit.TypeOfPet = model.TypeOfPet;
                    await db.SaveChangesAsync();
                }
            });
        }

        public async Task DeleteAsync(PatientModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var remove = await db.Patients.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (remove != null)
                {
                    db.Patients.Remove(remove);
                    await db.SaveChangesAsync();
                }
            });
        }
    }
}