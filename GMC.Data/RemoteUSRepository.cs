using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class RemoteUSRepository : IRemoteUSRepository
    {
        private readonly DataContext dataContext;

        public RemoteUSRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<RemoteUS> CreateRemoteUSAsync(RemoteUS remoteUS)
        {
            dataContext.RemoteUS.Add(remoteUS);
            await dataContext.SaveChangesAsync();
            return remoteUS;
        }

        public async Task<bool> DeleteRemoteUSAsync(int remoteUSId)
        {
            var remoteUSToRemove = await dataContext.RemoteUS.FindAsync(remoteUSId);
            dataContext.RemoteUS.Remove(remoteUSToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public RemoteUS GetRemoteUS(int remoteUSId)
        {
            return this.dataContext.RemoteUS.Find(remoteUSId);
        }

        public Task<RemoteUS> GetRemoteUSAsync(int remoteUSId)
        {
            return this.dataContext.RemoteUS.FindAsync(remoteUSId).AsTask();
        }

        public List<RemoteUS> GetRemoteUSs()
        {
            var remoteUSs = dataContext.RemoteUS.ToList();
            return remoteUSs;
        }

        public Task<List<RemoteUS>> GetRemoteUSsAsync()
        {
            var remoteUSs = dataContext.RemoteUS.Include(l => l.USPickLists).ToListAsync();
            return remoteUSs;
        }

        public async Task<RemoteUS> UpdateRemoteUSAsync(RemoteUS remoteUS)
        {
            dataContext.RemoteUS.Update(remoteUS);
            await dataContext.SaveChangesAsync();
            return remoteUS;
        }

    }
}
