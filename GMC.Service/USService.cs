using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class USService : IUSService
    {
        private readonly IUSRepository usRepository;
        public USService(IUSRepository usRepository)
        {
            this.usRepository = usRepository;
        }
        public Task<US> CreateUSAsync(US us)
        {
            return usRepository.CreateUSAsync(us);
        }

        public Task<US> GetUSAsync(string NumUS)
        {
            return usRepository.GetUSAsync(NumUS);
        }

        public Task<List<US>> GetUSsAsync()
        {
             return usRepository.GetUSsAsync();
        }
    }
}
