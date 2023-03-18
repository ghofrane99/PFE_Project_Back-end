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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;
        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await statusService.GetStatusesAsync();
            return Ok(statuses);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatus([FromBody] CreateStatus createStatus)
        {
            var entityToAdd = new Status()
            {
                Code = createStatus.Code
            };

            var createdStatus = await statusService.CreateStatusAsync(entityToAdd);
            return Ok(createdStatus);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStatus updateStatus)
        {
            var entityToUpdate = await statusService.GetStatusAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            entityToUpdate.Code = updateStatus.Code;
            var updatedStatus = await statusService.UpdateStatusAsync(entityToUpdate);
            return Ok(updatedStatus);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await statusService.GetStatusAsync(id);
            if (status == null)
                return NotFound();
            var isSucces = await statusService.DeleteStatusAsync(id);
            return Ok();
        }

    }
}
