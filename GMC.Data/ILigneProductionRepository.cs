using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public interface ILigneProductionRepository
    {
        LigneProduction GetLigneProduction(int ligneProductionId);
        Task<LigneProduction> GetLigneProductionAsync(int ligneProductionId);
        List<LigneProduction> GetLigneProductions();
        Task<List<LigneProduction>> GetLigneProductionsAsync();
        Task<LigneProduction> CreateLigneProductionAsync(LigneProduction ligneProduction);
        Task<LigneProduction> UpdateLigneProductionAsync(LigneProduction ligneProduction);
        Task<bool> DeleteLigneProductionAsync(int ligneProductionId);

    }
}
