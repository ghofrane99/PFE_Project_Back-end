using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class USPickListService : IUSPickListService
    {
        private readonly IUSPickListRepository usPickListRepository;
        public USPickListService(IUSPickListRepository usPickListRepository)
        {
            this.usPickListRepository = usPickListRepository;
        }
        public Task<USPickList> CreateUSPickListAsync(USPickList usPickList)
        {
            return usPickListRepository.CreateUSPickListAsync(usPickList);
        }
        public Task<bool> DeleteUSPickListAsync(string NumUS)
        {
            return usPickListRepository.DeleteUSPickListAsync(NumUS);
        }

        public USPickList GetUSPickList(string NumUS)
        {
            return usPickListRepository.GetUSPickList(NumUS);
        }

        public Task<USPickList> GetUSPickListAsync(string NumUS)
        {
            return usPickListRepository.GetUSPickListAsync(NumUS);
        }

        public List<USPickList> GetUSPickLists()
        {
            return usPickListRepository.GetUSPickLists();
        }

        public Task<List<USPickList>> GetUSPickListsAsync()
        {
            return usPickListRepository.GetUSPickListsAsync();
        }

        public Task<USPickList> UpdateUSPickListAsync(USPickList usPickList)
        {
            return usPickListRepository.UpdateUSPickListAsync(usPickList);
        }

    }
}
