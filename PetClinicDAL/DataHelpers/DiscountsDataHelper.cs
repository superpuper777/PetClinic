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
    public class DiscountsDataHelper : DataHelperBase, IDiscountsDataHelper
    {
        public async Task<IEnumerable<DiscountModel>> GetListAsync(DiscountFilterModel filterModel)
        {
            var doctors = await QueryAsync<PetClinicContext, List<Discount>>(db =>
            {
                var discountsQuery = db.Discounts.Select(d => d);
                if (!string.IsNullOrEmpty(filterModel.Name))
                    discountsQuery = discountsQuery.Where(d => d.Name.Contains(filterModel.Name));
                if (filterModel.Percent > 0)
                    discountsQuery = discountsQuery.Where(d => d.Percent == filterModel.Percent);
                return discountsQuery.ToListAsync();
            });

            return doctors.Select(d => new DiscountModel
            {
                Id = d.Id,
                Name = d.Name,
                Date = d.Date,
                Percent = d.Percent
            });
        }

        public async Task<int> AddAsync(DiscountModel model)
        {
            var newId = 0;
            await QueryAsync<PetClinicContext>(async db =>
            {
                db.Discounts.Add(new Discount
                {
                    Name = model.Name,
                    Date = model.Date,
                    Percent = model.Percent
                });
                newId = await db.SaveChangesAsync();
            });
            return newId;
        }

        public async Task EditAsync(DiscountModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var edit = await db.Discounts.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (edit != null)
                {
                    edit.Name = model.Name;
                    edit.Date = model.Date;
                    edit.Percent = model.Percent;
                    await db.SaveChangesAsync();
                }
            });
        }

        public async Task DeleteAsync(DiscountModel model)
        {
            await QueryAsync<PetClinicContext>(async db =>
            {
                var remove = await db.Discounts.FirstOrDefaultAsync(d => d.Id == model.Id);
                if (remove != null)
                {
                    db.Discounts.Remove(remove);
                    await db.SaveChangesAsync();
                }
            });
        }
    }
}