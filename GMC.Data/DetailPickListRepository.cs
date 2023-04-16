using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class DetailPickListRepository : IDetailPickListRepository
    {
        private readonly DataContext dataContext;
        public DetailPickListRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<DetailPickList> CreateDetailPickListAsync(DetailPickList detailPickList)
        {
            dataContext.DetailPickList.Add(detailPickList);
            await dataContext.SaveChangesAsync();
            return detailPickList;
        }

        public async Task<bool> DeleteDetailPickListAsync(int detailPickListId)
        {
            var detailPickListToRemove = await dataContext.DetailPickList.FindAsync(detailPickListId);
            dataContext.DetailPickList.Remove(detailPickListToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public DetailPickList GetDetailPickList(int detailPickListId)
        {
            return this.dataContext.DetailPickList.Find(detailPickListId);
        }

        public Task<DetailPickList> GetDetailPickListAsync(int detailPickListId)
        {
            return this.dataContext.DetailPickList.FindAsync(detailPickListId).AsTask();
        }

        public List<DetailPickList> GetDetailPickLists()
        {

            var detailPickLists = dataContext.DetailPickList.ToList();
            return detailPickLists;
        }

        public async Task<List<DetailPickListDTO>> GetDetailPickListsAsync()
        {

            var detailPickLists = await dataContext.DetailPickList.Include(c => c.PickList).Include(c => c.Produit).Include(c => c.Status)
                .Select(p => new DetailPickListDTO
                {
                    IdDetailPickList = p.IdPickDetail,
                    PickList = p.PickList.NumPickList,
                    Produit =p.Produit.CodeProduit,
                    Emplacement =p.Emplacement,
                    QuantiteDemande =p.QuantiteDemande,
                    Status = p.Status.Code,
                    NombreUS = p.NombreUS,
                    Skipped= p.Skipped,
                    PickListId = p.PickListId,
                    ProduitId = p.ProduitId,
                    StatusId = p.StatusId,


                }).ToListAsync();
            return detailPickLists;
        }

        public async Task<DetailPickList> UpdateDetailPickListAsync(DetailPickList detailPickList)
        {
            dataContext.DetailPickList.Update(detailPickList);
            await dataContext.SaveChangesAsync();
            return detailPickList;
        }
    }
}
