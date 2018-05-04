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
    public class DiagramDataHelper : DataHelperBase, IDiagramDataHelper
    {
        public async Task<DiagramModel> GetDiagramDataAsync()
        {
            var list = await QueryAsync<PetClinicContext, List<IGrouping<DateTime, Reception>>>(db =>
            {
                var res = db.Receptions.GroupBy(r => r.Date).Select(r => r);

                return res.ToListAsync();
            });

            return new DiagramModel
            {
                Dates = list.Select(l => l.Key.ToShortDateString()).ToList(),
                Counts = list.Select(l => l.Count()).ToList()
            };

        }
    }
}