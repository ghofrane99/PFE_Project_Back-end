using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class DetailPickListService : IDetailPickListService
    {
        private readonly IDetailPickListRepository detailPickListRepository;
        public DetailPickListService(IDetailPickListRepository detailPickListRepository)
        {
            this.detailPickListRepository = detailPickListRepository;
        }
        public Task<DetailPickList> CreateDetailPickListAsync(DetailPickList detailPickList)
        {
            return detailPickListRepository.CreateDetailPickListAsync(detailPickList);
        }

        public Task<bool> DeleteDetailPickListAsync(int detailPickListId)
        {
            return detailPickListRepository.DeleteDetailPickListAsync(detailPickListId);
        }

        public DetailPickList GetDetailPickList(int detailPickListId)
        {
            return detailPickListRepository.GetDetailPickList(detailPickListId);
        }

        public Task<DetailPickList> GetDetailPickListAsync(int detailPickListId)
        {
            return detailPickListRepository.GetDetailPickListAsync(detailPickListId);
        }

        public List<DetailPickList> GetDetailPickLists()
        {
            return detailPickListRepository.GetDetailPickLists();
        }

        public Task<List<DetailPickListDTO>> GetDetailPickListsAsync()
        {
            return detailPickListRepository.GetDetailPickListsAsync();
        }

        public Task<DetailPickList> UpdateDetailPickListAsync(DetailPickList detailPickList)
        {
            return detailPickListRepository.UpdateDetailPickListAsync(detailPickList);
        }
    }
}
