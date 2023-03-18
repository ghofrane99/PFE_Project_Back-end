﻿using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public interface IDetailPickListService
    {
        DetailPickList GetDetailPickList(int detailPickListId);
        Task<DetailPickList> GetDetailPickListAsync(int detailPickListId);
        List<DetailPickList> GetDetailPickLists();
        Task<List<DetailPickList>> GetDetailPickListsAsync();
        Task<DetailPickList> CreateDetailPickListAsync(DetailPickList detailPickList);
        Task<DetailPickList> UpdateDetailPickListAsync(DetailPickList detailPickList);
        Task<bool> DeleteDetailPickListAsync(int detailPickListId);
    }
}
