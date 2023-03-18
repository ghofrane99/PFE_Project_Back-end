using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class USPickListRepository : IUSPickListRepository
    {
        private readonly DataContext dataContext;
        public USPickListRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }
        public async Task<USPickList> CreateUSPickListAsync(USPickList usPickList)
        {
            dataContext.USPickList.Add(usPickList);
            await dataContext.SaveChangesAsync();
            return usPickList;
        }

        public async Task<bool> DeleteUSPickListAsync(string NumUS)
        {

            var usPickListToRemove = await dataContext.USPickList.FindAsync(NumUS);
            dataContext.USPickList.Remove(usPickListToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public USPickList GetUSPickList(string NumUS)
        {
            return this.dataContext.USPickList.Find(NumUS);
        }

        public Task<USPickList> GetUSPickListAsync(string NumUS)
        {
            return this.dataContext.USPickList.FindAsync(NumUS).AsTask();
        }

        public List<USPickList> GetUSPickLists()
        {
            var usPickLists = dataContext.USPickList.ToList();
            return usPickLists;
        }

        public Task<List<USPickList>> GetUSPickListsAsync()
        {

            var usPickLists = dataContext.USPickList.ToListAsync();
            return usPickLists;
        }

        public async Task<USPickList> UpdateUSPickListAsync(USPickList usPickList)
        {

            dataContext.USPickList.Update(usPickList);
            await dataContext.SaveChangesAsync();
            return usPickList;
        }
    }
}
