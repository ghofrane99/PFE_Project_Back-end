﻿using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public interface IPickListService
    {
        PickList GetPickList(int pickListId);
        Task<PickList> GetPickListAsync(int pickListId);
        List<PickList> GetPickLists();
        Task<List<PickList>> GetPickListsAsync();
        Task<PickList> CreatePickListAsync(PickList pickList);
        Task<PickList> UpdatePickListAsync(PickList pickList);
        Task<bool> DeletePickListAsync(int pickListId);
    }
}