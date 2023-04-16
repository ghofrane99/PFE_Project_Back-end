using GMC.API.ViewModel.Create;
using GMC.API.ViewModel.Update;
using GMC.Core;
using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IProduitService produitService;
        public ProduitController(IProduitService produitService, DataContext dataContext)
        {
            this.produitService = produitService;
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduit()
        {
            var produits = await produitService.GetProduitsAsync();
            return Ok(produits);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduit([FromBody] CreateProduit createProduit)
        {
            var entityToAdd = new Produit()
            {
                CodeProduit = createProduit.CodeProduit,
                Seuil = createProduit.Seuil,
                Etat = createProduit.Etat,
                DateCreation = DateTime.Now,
                DateMaj = null,
                Designation = createProduit.Designation,
                CreerPar = createProduit.CreerPar

            };

            var createdProduit = await produitService.CreateProduitAsync(entityToAdd);
            return Ok(createdProduit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduit(int id, [FromBody] UpdateProduit updateProduit)
        {
            var entityToUpdate = await produitService.GetProduitAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }

            entityToUpdate.CodeProduit = updateProduit.CodeProduit;
            entityToUpdate.Seuil = updateProduit.Seuil;
            entityToUpdate.Etat = updateProduit.Etat;
            entityToUpdate.DateMaj = DateTime.Now;
            entityToUpdate.Designation = updateProduit.Designation;
            entityToUpdate.CreerPar = updateProduit.CreerPar;



            var updatedProduit = await produitService.UpdateProduitAsync(entityToUpdate);
            return Ok(updatedProduit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await produitService.GetProduitAsync(id);
            if (produit == null)
                return NotFound();
            var isSucces = await produitService.DeleteProduitAsync(id);
            return Ok();
        }
        [HttpGet("checkCode/{code}")]
        public async Task<ActionResult<bool>> CheckCodeExists(int code)
        {
            var result = await dataContext.Produit.AnyAsync(lp => lp.CodeProduit ==code);
            return Ok(result);
        }

    }
}
