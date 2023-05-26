using GMC.API.ViewModel.Create;
using GMC.Core;
using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using GMC.API.ViewModel.Update;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickListController : ControllerBase
    {
        private DataContext dataContext;
        private readonly IPickListService pickListService;
        public PickListController(IPickListService pickListService, DataContext dataContext)
        {
            this.pickListService = pickListService;
            this.dataContext = dataContext;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var pickList = await pickListService.GetPickListAsync(id);
            return Ok(pickList);
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
                DateCreation = DateTime.Now,
                DateMaj = null,
                TypePickList = null,
                CodeProduit = null,
                DateLivraison = null,
                DateServi = null,
                NbUSServi = null,
                NbUSRecept = null,
                Observation = null,
                IdCauseServi = null,
                PrintedServi = null,
                DemandeAnnulation = null,
                DemandeSuppPar = null,
                ApprobSuppPar = null,
                DateDemandeSuppression = null,
                DateApprobSuppression = null,
                NbUSReceptCond = null,
                SetEmp = null,
                CreerPar= createPickList.CreerPar,
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


            entityToUpdate.StatusId = updatePickList.StatusId;
            entityToUpdate.DateMaj = DateTime.Now;



            var updatedPickList = await pickListService.UpdatePickListAsync(entityToUpdate);
            return Ok(updatedPickList);
        }
        [HttpPut("UpdateNBUS/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePickListNBUS updatePickListNBUS)
        {
            var entityToUpdate = await pickListService.GetPickListAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }


            entityToUpdate.NbUSServi = updatePickListNBUS.NbUSServi;
           entityToUpdate.NbUSRecept = updatePickListNBUS.NbUSRecept;
            entityToUpdate.DateLivraison = updatePickListNBUS.DateLivraison;
            entityToUpdate.DateServi= updatePickListNBUS.DateServi;


            var updatedPickList = await pickListService.UpdatePickListAsync(entityToUpdate);
            return Ok(updatedPickList);
        }
        [HttpPut("ByNumPickList/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateNumPickList updateNumPickList)
        {
            var entityToUpdate = await pickListService.GetPickListAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }


            entityToUpdate.NumPickList = updateNumPickList.NumPickList;



            var updatedPickList = await pickListService.UpdatePickListAsync(entityToUpdate);
            return Ok(updatedPickList);
        }
        [HttpGet("report")]
        public async Task<ActionResult> GetReport()
        {
            var pdfBase64 = await pickListService.GeneratePickListReportAsync();
            return Ok(pdfBase64);
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
        [HttpGet("checkCode/{code}")]
        public async Task<ActionResult<bool>> CheckCodeExists(string code)
        {
            var result = await dataContext.PickList.AnyAsync(lp => lp.NumPickList == code);
            return Ok(result);
        }
    }
}