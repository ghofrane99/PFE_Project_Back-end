using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public interface IDetailPickListRepository
    {
        DetailPickList GetDetailPickList(int detailPickListId);
        Task<DetailPickList> GetDetailPickListAsync(int detailPickListId);
        List<DetailPickList> GetDetailPickLists();
        Task<List<DetailPickListDTO>> GetDetailPickListsAsync();
        Task<DetailPickList> CreateDetailPickListAsync(DetailPickList detailPickList);
        Task<DetailPickList> UpdateDetailPickListAsync(DetailPickList detailPickList);
        Task<bool> DeleteDetailPickListAsync(int detailPickListId);

    }
}
