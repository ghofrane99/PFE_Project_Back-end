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

        public Task<List<DetailPickList>> GetDetailPickListsAsync()
        {

            var detailPickLists = dataContext.DetailPickList.Include(c => c.PickList).Include(c => c.Produit).ThenInclude(d => d.DetailPickLists).ToListAsync();
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
