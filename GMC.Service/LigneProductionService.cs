using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class LigneProductionService : ILigneProductionService
    {
        private readonly ILigneProductionRepository ligneProductionRepository;
        public LigneProductionService(ILigneProductionRepository ligneProductionRepository)
        {
            this.ligneProductionRepository = ligneProductionRepository;

        }
        public Task<LigneProduction> CreateLigneProductionAsync(LigneProduction ligneProduction)
        {
            return ligneProductionRepository.CreateLigneProductionAsync(ligneProduction);
        }

        public Task<bool> DeleteLigneProductionAsync(int ligneProductionId)
        {
            return ligneProductionRepository.DeleteLigneProductionAsync(ligneProductionId);
        }

        public LigneProduction GetLigneProduction(int ligneProductionId)
        {
            return ligneProductionRepository.GetLigneProduction(ligneProductionId);
        }

        public Task<LigneProduction> GetLigneProductionAsync(int ligneProductionId)
        {
            return ligneProductionRepository.GetLigneProductionAsync(ligneProductionId);
        }

        public List<LigneProduction> GetLigneProductions()
        {
            return ligneProductionRepository.GetLigneProductions();
        }

        public Task<List<LigneProduction>> GetLigneProductionsAsync()
        {
            return ligneProductionRepository.GetLigneProductionsAsync();
        }

        public Task<LigneProduction> UpdateLigneProductionAsync(LigneProduction ligneProduction)
        {
            return ligneProductionRepository.UpdateLigneProductionAsync(ligneProduction);
        }
    }
}
