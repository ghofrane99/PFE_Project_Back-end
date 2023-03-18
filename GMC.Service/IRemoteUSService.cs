using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public interface IRemoteUSService
    {
        RemoteUS GetRemoteUS(int remoteUSId);
        Task<RemoteUS> GetRemoteUSAsync(int remoteUSId);
        List<RemoteUS> GetRemoteUSs();
        Task<List<RemoteUS>> GetRemoteUSsAsync();
        Task<RemoteUS> CreateRemoteUSAsync(RemoteUS remoteUS);
        Task<RemoteUS> UpdateRemoteUSAsync(RemoteUS remoteUS);
        Task<bool> DeleteRemoteUSAsync(int remoteUSId);
    }
}
