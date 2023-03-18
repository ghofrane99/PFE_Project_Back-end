using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class ProduitService : IProduitService
    {
        private readonly IProduitRepository produitRepository;
        public ProduitService(IProduitRepository produitRepository)
        {
            this.produitRepository = produitRepository;
        }
        public Task<Produit> CreateProduitAsync(Produit produit)
        {
            return produitRepository.CreateProduitAsync(produit);
        }

        public Task<bool> DeleteProduitAsync(int produitId)
        {
            return produitRepository.DeleteProduitAsync(produitId);
        }

        public Produit GetProduit(int produitId)
        {
            return produitRepository.GetProduit(produitId);
        }

        public Task<Produit> GetProduitAsync(int produitId)
        {
            return produitRepository.GetProduitAsync(produitId);
        }

        public List<Produit> GetProduits()
        {
            return produitRepository.GetProduits();
        }

        public Task<List<Produit>> GetProduitsAsync()
        {
            return produitRepository.GetProduitsAsync();
        }

        public Task<Produit> UpdateProduitAsync(Produit produit)
        {
            return produitRepository.UpdateProduitAsync(produit);
        }
    }
}
