using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly DataContext dataContext;
        public ProduitRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<Produit> CreateProduitAsync(Produit produit)
        {

            dataContext.Produit.Add(produit);
            await dataContext.SaveChangesAsync();
            return produit;
        }

        public async Task<bool> DeleteProduitAsync(int produitId)
        {
            var produitToRemove = await dataContext.Produit.FindAsync(produitId);
            dataContext.Produit.Remove(produitToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public Produit GetProduit(int produitId)
        {
            return this.dataContext.Produit.Find(produitId);
        }

        public Task<Produit> GetProduitAsync(int produitId)
        {
            return this.dataContext.Produit.FindAsync(produitId).AsTask();
        }

        public List<Produit> GetProduits()
        {

            var produits = dataContext.Produit.ToList();
            return produits;
        }

        public Task<List<Produit>> GetProduitsAsync()
        {
            var produits = dataContext.Produit.ToListAsync();
            return produits;
        }

        public async Task<Produit> UpdateProduitAsync(Produit produit)
        {

            dataContext.Produit.Update(produit);
            await dataContext.SaveChangesAsync();
            return produit;
        }
    }
}
