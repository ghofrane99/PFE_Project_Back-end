using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public interface IStatusService
    {
        Status GetStatus(int statusId);
        Task<Status> GetStatusAsync(int statusId);
        List<Status> GetStatuses();
        Task<List<Status>> GetStatusesAsync();
        Task<Status> CreateStatusAsync(Status status);
        Task<Status> UpdateStatusAsync(Status status);
        Task<bool> DeleteStatusAsync(int statusId);
    }
}
