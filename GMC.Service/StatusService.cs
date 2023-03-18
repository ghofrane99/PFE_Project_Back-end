using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }
        public Task<Status> CreateStatusAsync(Status status)
        {
            return statusRepository.CreateStatusAsync(status);
        }

        public Task<bool> DeleteStatusAsync(int statusId)
        {
            return statusRepository.DeleteStatusAsync(statusId);
        }

        public Status GetStatus(int statusId)
        {
            return statusRepository.GetStatus(statusId);
        }

        public Task<Status> GetStatusAsync(int statusId)
        {
            return statusRepository.GetStatusAsync(statusId);
        }

        public List<Status> GetStatuses()
        {
            return statusRepository.GetStatuses();
        }

        public Task<List<Status>> GetStatusesAsync()
        {
            return statusRepository.GetStatusesAsync();
        }

        public Task<Status> UpdateStatusAsync(Status status)
        {
            return statusRepository.UpdateStatusAsync(status);
        }
    }
}
