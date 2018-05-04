using System;
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
    public class DoctorsDataHelper : DataHelperBase, IDoctorsDataHelper
    {
        public async Task<IEnumerable<DoctorModel>> GetListAsync(DoctorFilterModel filterModel)
        {       
            var doctors = await QueryAsync<PetClinicContext, List<Doctor>>(db =>
            {
                var doctorsQuery = db.Doctors.Select(d => d);
                if (!string.IsNullOrEmpty(filterModel.Name))
                    doctorsQuery = doctorsQuery.Where(d => d.Name.Contains(filterModel.Name));
                if (!string.IsNullOrEmpty(filterModel.Specialisation))
                    doctorsQuery = doctorsQuery.Where(d => d.Specialisation.Contains(filterModel.Specialisation));
                return doctorsQuery.ToListAsync();
            });

            return doctors.Select(d => new DoctorModel
            {
                Id = d.Id,
                Name = d.Name,
                Specialisation = d.Specialisation
            });
        }

        public async Task AddAsync(DoctorModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                db.Doctors.Add(new Doctor
                {
                    Id = model.Id,
                    Name = model.Name,
                    Specialisation = model.Specialisation,
                });
                await db.SaveChangesAsync();
            });
        }

        public async Task EditAsync(DoctorModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var edit = await db.Doctors.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (edit != null)
                {
                    edit.Name = model.Name;
                    edit.Specialisation = model.Specialisation;
                    await db.SaveChangesAsync();
                }
            });
        }

        public async Task DeleteAsync(DoctorModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var remove = await db.Doctors.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (remove != null)
                {
                    db.Doctors.Remove(remove);
                    await db.SaveChangesAsync();
                }
            });
        }
    }
}