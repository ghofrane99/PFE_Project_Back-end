﻿using GMC.API.ViewModel.Create;
using GMC.API.ViewModel.Update;
using GMC.Core;
using GMC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly IProduitService produitService;
        public ProduitController(IProduitService produitService)
        {
            this.produitService = produitService;
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
                Preparateur = createProduit.Preparateur,
                DateCreation = createProduit.DateCreation,
                DateMaj = createProduit.DateMaj,
                Designation = createProduit.Designation,
                Hostname = createProduit.Hostname

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
            entityToUpdate.Preparateur = updateProduit.Preparateur;
            entityToUpdate.DateCreation = updateProduit.DateCreation;
            entityToUpdate.DateMaj = updateProduit.DateMaj;
            entityToUpdate.Designation = updateProduit.Designation;
            entityToUpdate.Hostname = updateProduit.Hostname;



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

    }
}