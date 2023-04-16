using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class PickListRepository : IPickListRepository
    {
        private readonly DataContext dataContext;
        public PickListRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }

        public async Task<PickList> CreatePickListAsync(PickList pickList)
        {
            dataContext.PickList.Add(pickList);
            await dataContext.SaveChangesAsync();
            return pickList;
        }

        public async Task<bool> DeletePickListAsync(int pickListId)
        {
            var pickListToRemove = await dataContext.PickList.FindAsync(pickListId);
            dataContext.PickList.Remove(pickListToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public List<PickList> GetPickLists()
        {
            var pickLists = dataContext.PickList.ToList();
            return pickLists;
        }

        public PickList GetPickList(int pickListId)
        {
            return this.dataContext.PickList.Find(pickListId);

        }

        public async Task<List<PickListDTO>> GetPickListsAsync()
        {
            var pickLists = await dataContext.PickList.Include(p => p.LigneProduction).Include(p => p.Status)
                                          .Select(p => new PickListDTO
                                          {
                                              IdPickList = p.IdPickList,
                                              NumPickList = p.NumPickList,
                                              Magasin = p.Magasin,
                                              DateCreation = p.DateCreation,
                                              DateMaj = p.DateMaj,
                                              TypePickList = p.TypePickList,
                                              CodeProduit = p.CodeProduit,
                                              DateLivraison = p.DateLivraison,
                                              DateServi = p.DateServi,
                                              NbUSServi = p.NbUSServi,
                                              NbUSRecept = p.NbUSRecept,
                                              Observation = p.Observation,
                                              IdCauseServi = p.IdCauseServi,
                                              PrintedServi = p.PrintedServi,
                                              DemandeAnnulation = p.DemandeAnnulation,
                                              DemandeSuppPar = p.DemandeSuppPar,
                                              ApprobSuppPar = p.ApprobSuppPar,
                                              DateDemandeSuppression = p.DateDemandeSuppression,
                                              DateApprobSuppression = p.DateApprobSuppression,
                                              NbUSReceptCond = p.NbUSReceptCond,
                                              SetEmp = p.SetEmp,
                               
                                              CodeLigneProduction = p.LigneProduction.CodeLigneProduction,
                                              Code = p.Status.Code,
                                              LigneProductionId = p.LigneProductionId,
                                              StatusId = p.StatusId,
                                          })
                                          .ToListAsync();

            return pickLists;
        }

        public Task<PickList> GetPickListAsync(int pickListId)
        {
            return this.dataContext.PickList.FindAsync(pickListId).AsTask();

        }

        public async Task<PickList> UpdatePickListAsync(PickList pickList)
        {
            dataContext.PickList.Update(pickList);
            await dataContext.SaveChangesAsync();
            return pickList;
        }
    }
}
