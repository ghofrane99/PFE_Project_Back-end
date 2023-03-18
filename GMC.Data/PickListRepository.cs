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

        public Task<List<PickList>> GetPickListsAsync()
        {
            var pickLists = dataContext.PickList.Include(c => c.LigneProduction).Include(s => s.Status).ToListAsync();
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
