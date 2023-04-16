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
    public class USPickListController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IUSPickListService usPickListService;
        public USPickListController(IUSPickListService usPickListService, DataContext dataContext)
        {
            this.usPickListService = usPickListService;
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUSPickList()
        {
            var usPickLists = await usPickListService.GetUSPickListsAsync();
            return Ok(usPickLists);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUSPickList([FromBody] CreateUSPickList createUSPickList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToAdd = new USPickList()
            {
                NumUS = createUSPickList.NumUS,
                PickListId = createUSPickList.PickListId,
                Quantite = createUSPickList.Quantite,
                StatusId = createUSPickList.StatusId,
                CodeProduit = createUSPickList.CodeProduit,
                DateCreation = DateTime.Now,
                DateMaj = null,
                Source = null,
                CreationPar = createUSPickList.CreationPar,
                MajPar = null
            };

            var createdUSPickList = await usPickListService.CreateUSPickListAsync(entityToAdd);
            return Ok(createdUSPickList);
        }

        [HttpPut("{NumUS}")]
        public async Task<IActionResult> UpdateUSPickList(string NumUS, [FromBody] UpdateUSPickList updateUSPickList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToUpdate = await dataContext.USPickList
                .SingleOrDefaultAsync(u => u.NumUS == NumUS);

            if (entityToUpdate == null)
            {
                return NotFound();
            }

            entityToUpdate.PickListId = updateUSPickList.PickListId;
            entityToUpdate.Quantite = updateUSPickList.Quantite;
            entityToUpdate.StatusId = updateUSPickList.StatusId;
            entityToUpdate.CodeProduit = updateUSPickList.CodeProduit;
            entityToUpdate.DateMaj = DateTime.Now;
            entityToUpdate.Source = updateUSPickList.Source;
            entityToUpdate.MajPar = updateUSPickList.MajPar;

            var updatedUSPickList = await usPickListService.UpdateUSPickListAsync(entityToUpdate);
            return Ok(updatedUSPickList);
        }

        [HttpDelete("{NumUS}")]
        public async Task<IActionResult> DeleteUSPickList(string NumUS)
        {
            var usPickList = await usPickListService.GetUSPickListAsync(NumUS);
            if (usPickList == null)
            {
                return NotFound();
            }

            var isSuccess = await usPickListService.DeleteUSPickListAsync(NumUS);
            if (!isSuccess)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }




    }
}
