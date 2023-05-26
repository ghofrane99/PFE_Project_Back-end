using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class USRepository : IUSRepository
    {
        private readonly DataContext dataContext;
        public USRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }
        public async Task<US> CreateUSAsync(US us)
        {

            dataContext.US.Add(us);
            await dataContext.SaveChangesAsync();
            return us;
        }

     

      

        public Task<List<US>> GetUSsAsync()
        {
            var uss = dataContext.US.ToListAsync();
            return uss;
        }


        public Task<US> GetUSAsync(string NumUS)
        {
            return this.dataContext.US.FindAsync(NumUS).AsTask();
        }

       
    }
}
