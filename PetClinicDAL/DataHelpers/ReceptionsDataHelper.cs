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
    public class ReceptionsDataHelper : DataHelperBase, IReceptionsDataHelper
    {
        public async Task<IEnumerable<ReceptionModel>> GetListAsync(ReceptionFilterModel filterModel)
        {
            var receptions =
                await QueryAsync<PetClinicContext, List<Reception>>(db =>
                {
                    var receptionsQuery = db.Receptions
                        .Include(t => t.Doctor)
                        .Include(t => t.Patient)
                        .Include(t => t.Status)
                        .Include(t => t.Service);

                    if (!string.IsNullOrEmpty(filterModel.Time))
                        receptionsQuery = receptionsQuery.Where(r => r.Time == filterModel.Time);
                    if (filterModel.DoctorId.HasValue && filterModel.DoctorId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.DoctorId == filterModel.DoctorId);
                    if (filterModel.PatientId.HasValue && filterModel.PatientId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.PatientId == filterModel.PatientId);
                    if (filterModel.ServiceId.HasValue && filterModel.ServiceId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.ServiceId == filterModel.ServiceId);
                    if (filterModel.StatusId.HasValue && filterModel.StatusId > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.StatusId == filterModel.StatusId);
                    if (filterModel.Discount > 0)
                        receptionsQuery = receptionsQuery.Where(r => r.Discount == filterModel.Discount);

                    return receptionsQuery.ToListAsync();
                });

            return receptions.Select(r => new ReceptionModel
            {
                Id = r.id,
                Date = r.Date,
                Time = r.Time,
                DoctorId = r.Doctor?.Id,
                PatientId = r.Patient?.Id,
                ServiceId = r.Service?.Id,
                StatusId = r.Status?.Id,
                Discount = r.Discount
            });
        }

        public async Task AddAsync(ReceptionModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                db.Receptions.Add(new Reception
                {
                    Date = model.Date,
                    Time = model.Time,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    ServiceId = model.ServiceId,
                    StatusId = model.StatusId.HasValue && model.StatusId > 0 ? model.StatusId : null,
                    Discount = model.Discount
                });
                await db.SaveChangesAsync();
            });
        }

        public async Task EditAsync(ReceptionModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var edit = await db.Receptions.FirstOrDefaultAsync(r => r.id == model.Id);
                if (edit != null)
                {
                    edit.Date = model.Date;
                    edit.Time = model.Time;
                    edit.DoctorId = model.DoctorId;
                    edit.PatientId = model.PatientId;
                    edit.ServiceId = model.ServiceId;
                    edit.StatusId = model.StatusId.HasValue && model.StatusId > 0 ? model.StatusId : null;
                    edit.Discount = model.Discount;
                    await db.SaveChangesAsync();
                }
            });
        }

        public async Task DeleteAsync(ReceptionModel model)
        {
            await QueryAsync<PetClinicContext>(async db => 
            {
                var remove = await db.Receptions.FirstOrDefaultAsync(r => r.id == model.Id);
                if (remove != null)
                {
                    db.Receptions.Remove(remove);
                    await db.SaveChangesAsync();
                }
            });
        }

        public async Task<List<string>> GetBusyTimeListOnDateAsync(BusyTimeListFilterModel model)
        {
            var receptionsOnDate = await QueryAsync<PetClinicContext, List<Reception>>(db => db.Receptions
                .Where(r => r.Date == model.Date && r.DoctorId == model.DoctorId)
                .ToListAsync());
            return receptionsOnDate.Select(r => r.Time).ToList();
        }
    }
}