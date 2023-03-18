using GMC.Core;
using GMC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using GMC.Service;
using GMC.API.ViewModel.Create;
using GMC.API.ViewModel.Update;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigneProductionController : ControllerBase
    {


        private readonly ILigneProductionService ligneProductionService;
        public LigneProductionController(ILigneProductionService ligneProductionService)
        {
            this.ligneProductionService = ligneProductionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLigneProduction()
        {
            var ligneProductions = await ligneProductionService.GetLigneProductionsAsync();
            return Ok(ligneProductions);

        }
        [HttpPost]
        public async Task<IActionResult> CreateLigneProduction([FromBody] CreateLigneProduction createLigneProduction)
        {
            var entityToAdd = new LigneProduction()
            {
                CodeLigneProduction = createLigneProduction.CodeLigneProduction,
                Etat = createLigneProduction.Etat,
                Observation = createLigneProduction.Observation,
                RobotTraitement = createLigneProduction.RobotTraitement,
                DateCreation = createLigneProduction.DateCreation,
                DateMaj = createLigneProduction.DateMaj,
                Hostname = createLigneProduction.Hostname,
                Boucle = createLigneProduction.Boucle,
                Forced = createLigneProduction.Forced,
                ProduitForced = createLigneProduction.ProduitForced


            };

            var createdLigneProduction = await ligneProductionService.CreateLigneProductionAsync(entityToAdd);
            return Ok(createdLigneProduction);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLigneProduction updateLigneProduction)
        {
            var entityToUpdate = await ligneProductionService.GetLigneProductionAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            entityToUpdate.CodeLigneProduction = updateLigneProduction.CodeLigneProduction;
            entityToUpdate.Etat = updateLigneProduction.Etat;
            entityToUpdate.Observation = updateLigneProduction.Observation;
            entityToUpdate.RobotTraitement = updateLigneProduction.RobotTraitement;
            entityToUpdate.DateCreation = updateLigneProduction.DateCreation;
            entityToUpdate.DateMaj = updateLigneProduction.DateMaj;
            entityToUpdate.Hostname = updateLigneProduction.Hostname;
            entityToUpdate.Boucle = updateLigneProduction.Boucle;
            entityToUpdate.Forced = updateLigneProduction.Forced;
            entityToUpdate.ProduitForced = updateLigneProduction.ProduitForced;



            var updatedLigneProduction = await ligneProductionService.UpdateLigneProductionAsync(entityToUpdate);
            return Ok(updatedLigneProduction);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ligneProduction = await ligneProductionService.GetLigneProductionAsync(id);
            if (ligneProduction == null)
                return NotFound();
            var isSucces = await ligneProductionService.DeleteLigneProductionAsync(id);
            return Ok();
        }
    }
}
