using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public interface IUSPickListRepository
    {
        USPickList GetUSPickList(string NumUS);
        Task<USPickList> GetUSPickListAsync(string NumUS);
        List<USPickList> GetUSPickLists();
        Task<List<USPickList>> GetUSPickListsAsync();
        Task<USPickList> CreateUSPickListAsync(USPickList usPickList);
        Task<USPickList> UpdateUSPickListAsync(USPickList usPickList);
        Task<bool> DeleteUSPickListAsync(string NumUS);

    }
}
