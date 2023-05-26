using GMC.API.ViewModel.Create;
using GMC.Core;
using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GMC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USController : ControllerBase
    {
        private readonly IUSService usService;
        public USController(IUSService usService)
        {
            this.usService = usService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetUS()
        {
            var uss = await usService.GetUSsAsync();
            return Ok(uss);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUS([FromBody] US us)
        {


            var US = await usService.CreateUSAsync(us);
            return Ok(US);
        }

    }
}
