using GMC.API.ViewModel.Create;
using GMC.Core;
using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using GMC.API.ViewModel.Update;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickListController : ControllerBase
    {
        private readonly IPickListService pickListService;
        public PickListController(IPickListService pickListService)
        {
            this.pickListService = pickListService;
        }
        // GET: api/<PickListController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var pickLists = await pickListService.GetPickListsAsync();
            return Ok(pickLists);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePickList createPickList)
        {
            var entityToAdd = new PickList()
            {
                NumPickList = createPickList.NumPickList,
                Magasin = createPickList.Magasin,
                DateCreation = createPickList.DateCreation,
                DateMaj = createPickList.DateMaj,
                TypePickList = createPickList.TypePickList,
                CodeProduit = createPickList.CodeProduit,
                DateLivraison = createPickList.DateLivraison,
                DateServi = createPickList.DateServi,
                NbUSServi = createPickList.NbUSServi,
                NbUSRecept = createPickList.NbUSRecept,
                Hostname = createPickList.Hostname,
                Observation = createPickList.Observation,
                IdCauseServi = createPickList.IdCauseServi,
                PrintedServi = createPickList.PrintedServi,
                DemandeAnnulation = createPickList.DemandeAnnulation,
                DemandeSuppPar = createPickList.DemandeSuppPar,
                ApprobSuppPar = createPickList.ApprobSuppPar,
                DateDemandeSuppression = createPickList.DateDemandeSuppression,
                DateApprobSuppression = createPickList.DateApprobSuppression,
                NbUSReceptCond = createPickList.NbUSReceptCond,
                SetEmp = createPickList.SetEmp,
                LigneProductionId = createPickList.LigneProductionId,
                StatusId = createPickList.StatusId

            };
            var createdPickList = await pickListService.CreatePickListAsync(entityToAdd);
            return Ok(createdPickList);


        }

        // PUT api/<PickListController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePickList updatePickList)
        {
            var entityToUpdate = await pickListService.GetPickListAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }

            entityToUpdate.NumPickList = updatePickList.NumPickList;
            entityToUpdate.Magasin = updatePickList.Magasin;
            entityToUpdate.DateCreation = updatePickList.DateCreation;
            entityToUpdate.DateMaj = updatePickList.DateMaj;
            entityToUpdate.TypePickList = updatePickList.TypePickList;
            entityToUpdate.CodeProduit = updatePickList.CodeProduit;
            entityToUpdate.DateLivraison = updatePickList.DateLivraison;
            entityToUpdate.DateServi = updatePickList.DateServi;
            entityToUpdate.NbUSServi = updatePickList.NbUSServi;
            entityToUpdate.NbUSRecept = updatePickList.NbUSRecept;
            entityToUpdate.Hostname = updatePickList.Hostname;
            entityToUpdate.Observation = updatePickList.Observation;
            entityToUpdate.IdCauseServi = updatePickList.IdCauseServi;
            entityToUpdate.PrintedServi = updatePickList.PrintedServi;
            entityToUpdate.DemandeAnnulation = updatePickList.DemandeAnnulation;
            entityToUpdate.DemandeSuppPar = updatePickList.DemandeSuppPar;
            entityToUpdate.ApprobSuppPar = updatePickList.ApprobSuppPar;
            entityToUpdate.DateDemandeSuppression = updatePickList.DateDemandeSuppression;
            entityToUpdate.DateApprobSuppression = updatePickList.DateApprobSuppression;
            entityToUpdate.NbUSReceptCond = updatePickList.NbUSReceptCond;
            entityToUpdate.SetEmp = updatePickList.SetEmp;
            entityToUpdate.LigneProductionId = updatePickList.LigneProductionId;
            entityToUpdate.StatusId = updatePickList.StatusId;



            var updatedPickList = await pickListService.UpdatePickListAsync(entityToUpdate);
            return Ok(updatedPickList);
        }

        // DELETE api/<PickListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pickList = await pickListService.GetPickListAsync(id);
            if (pickList == null)
                return NotFound();
            var isSucces = await pickListService.DeletePickListAsync(id);
            return Ok();
        }
    }
}
