using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class InformationUSRepository : IInformationUSRepository
    {
        private readonly DataContext dataContext;
        public InformationUSRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }
        public async Task<InformationUS> CreateInformationUSAsync(InformationUS informationUS)
        {
            dataContext.InformationUS.Add(informationUS);
            await dataContext.SaveChangesAsync();
            return informationUS;
        }

        public async Task<bool> DeleteInformationUSAsync(int informationUSId)
        {
            var informationUSToRemove = await dataContext.InformationUS.FindAsync(informationUSId);
            dataContext.InformationUS.Remove(informationUSToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public InformationUS GetInformationUS(int informationUSId)
        {
            return this.dataContext.InformationUS.Find(informationUSId);
        }

        public Task<InformationUS> GetInformationUSAsync(int informationUSId)
        {
            return this.dataContext.InformationUS.FindAsync(informationUSId).AsTask();
        }

        public List<InformationUS> GetInformationUSs()
        {
            var informationUSs = dataContext.InformationUS.ToList();
            return informationUSs;
        }

        public Task<List<InformationUS>> GetInformationUSsAsync()
        {
            var informationUSs = dataContext.InformationUS.ToListAsync();
            return informationUSs;
        }

        public async Task<InformationUS> UpdateInformationUSAsync(InformationUS informationUS)
        {
            dataContext.InformationUS.Update(informationUS);
            await dataContext.SaveChangesAsync();
            return informationUS;
        }

    }
}
