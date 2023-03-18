using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public interface IInformationUSService
    {
        InformationUS GetInformationUS(int informationUSId);
        Task<InformationUS> GetInformationUSAsync(int informationUSId);
        List<InformationUS> GetInformationUSs();
        Task<List<InformationUS>> GetInformationUSsAsync();
        Task<InformationUS> CreateInformationUSAsync(InformationUS informationUS);
        Task<InformationUS> UpdateInformationUSAsync(InformationUS informationUS);
        Task<bool> DeleteInformationUSAsync(int informationUSId);
    }
}
