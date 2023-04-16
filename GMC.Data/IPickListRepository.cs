using GMC.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public interface IPickListRepository
    {
        PickList GetPickList(int pickListId);
        Task<PickList> GetPickListAsync(int pickListId);
        List<PickList> GetPickLists();
        Task<List<PickListDTO>> GetPickListsAsync();
        Task<PickList> CreatePickListAsync(PickList pickList);
        Task<PickList> UpdatePickListAsync(PickList pickList);
        Task<bool> DeletePickListAsync(int pickListId);

    }
}
