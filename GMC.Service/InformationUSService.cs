using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class InformationUSService : IInformationUSService
    {
        private readonly IInformationUSRepository informationUSRepository;
        public InformationUSService(IInformationUSRepository informationUSRepository)
        {
            this.informationUSRepository = informationUSRepository;
        }

        public Task<InformationUS> CreateInformationUSAsync(InformationUS informationUS)
        {
            return informationUSRepository.CreateInformationUSAsync(informationUS);
        }

        public Task<bool> DeleteInformationUSAsync(int informationUSId)
        {
            return informationUSRepository.DeleteInformationUSAsync(informationUSId);
        }

        public InformationUS GetInformationUS(int informationUSId)
        {
            return informationUSRepository.GetInformationUS(informationUSId);
        }

        public Task<InformationUS> GetInformationUSAsync(int informationUSId)
        {
            return informationUSRepository.GetInformationUSAsync(informationUSId);
        }

        public List<InformationUS> GetInformationUSs()
        {
            return informationUSRepository.GetInformationUSs();
        }

        public Task<List<InformationUS>> GetInformationUSsAsync()
        {
            return informationUSRepository.GetInformationUSsAsync();
        }

        public Task<InformationUS> UpdateInformationUSAsync(InformationUS informationUS)
        {
            return informationUSRepository.UpdateInformationUSAsync(informationUS);
        }
    }
}
