using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public interface IUSService
    {
        Task<US> GetUSAsync(string NumUS);
        Task<List<US>> GetUSsAsync();
        Task<US> CreateUSAsync(US us);
    }
}
