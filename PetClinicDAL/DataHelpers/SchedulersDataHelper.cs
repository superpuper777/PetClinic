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
    public class SchedulersDataHelper: DataHelperBase, ISchedulersDataHelper
    {
        public async Task<IEnumerable<SchedulerModel>> GetListAsync(SchedulerFilterModel filterModel)
        {
            var schedulers =
                await QueryAsync<PetClinicContext, List<Scheduler>>(db =>
                {
                    var receptionsQuery = db.Schedulers
                        .Include(t => t.Doctor)
                        .Include(t => t.Patient)
                        .Include(t => t.Service);

                    if (!string.IsNullOrEmpty(filterModel.Time))
                        receptionsQuery = receptionsQuery.Where(r => r.Time == filterModel.Time);
                    if (filterModel.DoctorId.HasValue && filterModel.DoctorId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.DoctorId == filterModel.DoctorId);
                    if (filterModel.PatientId.HasValue && filterModel.PatientId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.PatientId == filterModel.PatientId);
                    if (filterModel.ServiceId.HasValue && filterModel.ServiceId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.ServiceId == filterModel.ServiceId);

                    return receptionsQuery.ToListAsync();
                });

            return schedulers.Select(r => new SchedulerModel
            {
                Id = r.Id,
                Date = r.Date,
                Time = r.Time,
                DoctorId = r.Doctor?.Id,
                PatientId = r.Patient?.Id,
                ServiceId = r.Service?.Id,
                
            });
        }
    }
}
