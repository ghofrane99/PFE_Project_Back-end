using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class PickListService : IPickListService
    {
        private readonly IPickListRepository pickListRepository;
        public PickListService(IPickListRepository pickListRepository)
        {
            this.pickListRepository = pickListRepository;

        }

        public Task<PickList> CreatePickListAsync(PickList pickList)
        {
            return pickListRepository.CreatePickListAsync(pickList);
        }

        public Task<bool> DeletePickListAsync(int pickListId)
        {
            return pickListRepository.DeletePickListAsync(pickListId);
        }

        public PickList GetPickList(int pickListId)
        {
            return pickListRepository.GetPickList(pickListId);
        }

        public Task<PickList> GetPickListAsync(int pickListId)
        {
            return pickListRepository.GetPickListAsync(pickListId);
        }

        public List<PickList> GetPickLists()
        {
            return pickListRepository.GetPickLists();
        }

        public Task<List<PickList>> GetPickListsAsync()
        {
            return pickListRepository.GetPickListsAsync();
        }

        public Task<PickList> UpdatePickListAsync(PickList pickList)
        {
            return pickListRepository.UpdatePickListAsync(pickList);
        }
    }
}
