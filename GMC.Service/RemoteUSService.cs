using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class RemoteUSService : IRemoteUSService
    {
        private readonly IRemoteUSRepository remoteUSRepository;
        public RemoteUSService(IRemoteUSRepository remoteUSRepository)
        {
            this.remoteUSRepository = remoteUSRepository;
        }
        public Task<RemoteUS> CreateRemoteUSAsync(RemoteUS remoteUS)
        {
            return remoteUSRepository.CreateRemoteUSAsync(remoteUS);
        }

        public Task<bool> DeleteRemoteUSAsync(int remoteUSId)
        {
            return remoteUSRepository.DeleteRemoteUSAsync(remoteUSId);
        }

        public RemoteUS GetRemoteUS(int remoteUSId)
        {
            return remoteUSRepository.GetRemoteUS(remoteUSId);
        }

        public Task<RemoteUS> GetRemoteUSAsync(int remoteUSId)
        {
            return remoteUSRepository.GetRemoteUSAsync(remoteUSId);
        }

        public List<RemoteUS> GetRemoteUSs()
        {
            return remoteUSRepository.GetRemoteUSs();
        }

        public Task<List<RemoteUS>> GetRemoteUSsAsync()
        {
            return remoteUSRepository.GetRemoteUSsAsync();
        }

        public Task<RemoteUS> UpdateRemoteUSAsync(RemoteUS remoteUS)
        {
            return remoteUSRepository.UpdateRemoteUSAsync(remoteUS);
        }
    }
}
