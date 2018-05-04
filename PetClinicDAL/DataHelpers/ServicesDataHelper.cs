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
    public class ServicesDataHelper : DataHelperBase, IServicesDataHelper
    {
        public async Task<IEnumerable<ServiceModel>> GetListAsync(ServiceFilterModel filterModel)
        {
            var patients = await QueryAsync<PetClinicContext, List<Service>>(db =>
            {
                var servicesQuery = db.Services.Select(s => s);
                if (!string.IsNullOrEmpty(filterModel.TypeOfServiceAndPr))
                    servicesQuery =
                        servicesQuery.Where(s => s.TypeOfServiceAndPr.Contains(filterModel.TypeOfServiceAndPr));
                if (!string.IsNullOrEmpty(filterModel.Amount))
                    servicesQuery =
                        servicesQuery.Where(s => s.Amount.Contains(filterModel.Amount));
                if (filterModel.Cost > 0)
                    servicesQuery =
                        servicesQuery.Where(s => s.Cost == filterModel.Cost);
                return servicesQuery.ToListAsync();
            });

            return patients.Select(s => new ServiceModel
            {
                Id = s.Id,
                TypeOfServiceAndPr = s.TypeOfServiceAndPr,
                Amount = s.Amount,
                Cost = s.Cost
            });
        }

        public async Task AddAsync(ServiceModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                db.Services.Add(new Service
                {
                    Id = model.Id,
                    Amount = model.Amount,
                    Cost = model.Cost,
                    TypeOfServiceAndPr = model.TypeOfServiceAndPr
                });
                await db.SaveChangesAsync();
            });
        }

        public async Task EditAsync(ServiceModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var edit = await db.Services.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (edit != null)
                {
                    edit.Id = model.Id;
                    edit.Amount = model.Amount;
                    edit.Cost = model.Cost;
                    edit.TypeOfServiceAndPr = model.TypeOfServiceAndPr;
                    await db.SaveChangesAsync();
                }
            });
        }

        public async Task DeleteAsync(ServiceModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var remove = await db.Services.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (remove != null)
                {
                    db.Services.Remove(remove);
                    await db.SaveChangesAsync();
                }
            });
        }
    }
}