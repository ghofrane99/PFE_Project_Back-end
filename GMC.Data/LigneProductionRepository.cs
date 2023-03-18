using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class LigneProductionRepository : ILigneProductionRepository
    {
        private readonly DataContext dataContext;
        public LigneProductionRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;

        }
        public async Task<LigneProduction> CreateLigneProductionAsync(LigneProduction ligneProduction)
        {
            dataContext.LigneProduction.Add(ligneProduction);
            await dataContext.SaveChangesAsync();
            return ligneProduction;
        }

        public async Task<bool> DeleteLigneProductionAsync(int ligneProductionId)
        {
            var ligneProductionToRemove = await dataContext.LigneProduction.FindAsync(ligneProductionId);
            dataContext.LigneProduction.Remove(ligneProductionToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public LigneProduction GetLigneProduction(int ligneProductionId)
        {
            return this.dataContext.LigneProduction.Find(ligneProductionId);

        }

        public Task<LigneProduction> GetLigneProductionAsync(int ligneProductionId)
        {
            return this.dataContext.LigneProduction.FindAsync(ligneProductionId).AsTask();
        }

        public List<LigneProduction> GetLigneProductions()
        {
            var ligneProductions = dataContext.LigneProduction.ToList();
            return ligneProductions;
        }

        public async Task<List<LigneProduction>> GetLigneProductionsAsync()
        {
            var ligneProductions = await dataContext.LigneProduction.Include(p => p.PickLists).ToListAsync();
            return ligneProductions;
        }

        public async Task<LigneProduction> UpdateLigneProductionAsync(LigneProduction ligneProduction)
        {
            dataContext.LigneProduction.Update(ligneProduction);
            await dataContext.SaveChangesAsync();
            return ligneProduction;
        }
    }
}
