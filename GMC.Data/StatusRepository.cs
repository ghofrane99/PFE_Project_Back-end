using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext dataContext;
        public StatusRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<Status> CreateStatusAsync(Status status)
        {
            dataContext.Status.Add(status);
            await dataContext.SaveChangesAsync();
            return status;
        }

        public async Task<bool> DeleteStatusAsync(int statusId)
        {

            var statusToRemove = await dataContext.Status.FindAsync(statusId);
            dataContext.Status.Remove(statusToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public Status GetStatus(int statusId)
        {
            return this.dataContext.Status.Find(statusId);
        }

        public Task<Status> GetStatusAsync(int statusId)
        {
            return this.dataContext.Status.FindAsync(statusId).AsTask();
        }

        public List<Status> GetStatuses()
        {
            var statuses = dataContext.Status.ToList();
            return statuses;
        }

        public Task<List<Status>> GetStatusesAsync()
        {
            var statuses = dataContext.Status.ToListAsync();
            return statuses;
        }

        public async Task<Status> UpdateStatusAsync(Status status)
        {
            dataContext.Status.Update(status);
            await dataContext.SaveChangesAsync();
            return status;
        }
    }
}
