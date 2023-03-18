using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public interface IProduitRepository
    {
        Produit GetProduit(int produitId);
        Task<Produit> GetProduitAsync(int produitId);
        List<Produit> GetProduits();
        Task<List<Produit>> GetProduitsAsync();
        Task<Produit> CreateProduitAsync(Produit produit);
        Task<Produit> UpdateProduitAsync(Produit produit);
        Task<bool> DeleteProduitAsync(int produitId);

    }
}
