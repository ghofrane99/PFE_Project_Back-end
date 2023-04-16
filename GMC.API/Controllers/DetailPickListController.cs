using GMC.API.ViewModel.Create;
using GMC.API.ViewModel.Update;
using GMC.Core;
using GMC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailPickListController : ControllerBase
    {

        private readonly IDetailPickListService detailPickListService;
        public DetailPickListController(IDetailPickListService detailPickListService)
        {
            this.detailPickListService = detailPickListService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDetailPickList()
        {
            var detailPickLists = await detailPickListService.GetDetailPickListsAsync();
            return Ok(detailPickLists);

        }

        [HttpPost]
        public async Task<IActionResult> CreateDetailPickList([FromBody] CreateDetailPickList createDetailPickList)
        {

            var entityToAdd = new DetailPickList()
            {
                PickListId = createDetailPickList.PickListId,
                ProduitId = createDetailPickList.ProduitId,
                Emplacement = null,
                QuantiteDemande = createDetailPickList.QuantiteDemande,
                StatusId = createDetailPickList.StatusId,
                NombreUS = null,
                Skipped = null

            };

            var createdDetailPickList = await detailPickListService.CreateDetailPickListAsync(entityToAdd);
            return Ok(createdDetailPickList);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetailPickList(int id, [FromBody] UpdateDetailPickList updateDetailPickList)
        {
            var entityToUpdate = await detailPickListService.GetDetailPickListAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }

            
            entityToUpdate.StatusId = updateDetailPickList.StatusId;
           

            var updatedDetailPickList = await detailPickListService.UpdateDetailPickListAsync(entityToUpdate);
            return Ok(updatedDetailPickList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailPickList(int id)
        {
            var detailPickList = await detailPickListService.GetDetailPickListAsync(id);
            if (detailPickList == null)
                return NotFound();
            var isSucces = await detailPickListService.DeleteDetailPickListAsync(id);
            return Ok();
        }

    }
}
