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
    public class RemoteUSController : ControllerBase
    {
        private readonly IRemoteUSService remoteUSService;
        private readonly DataContext dataContext;
        public RemoteUSController(IRemoteUSService remoteUSService, DataContext dataContext)
        {
            this.remoteUSService = remoteUSService;
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRemoteUS()
        {
            var remoteUSs = await remoteUSService.GetRemoteUSsAsync();
            return Ok(remoteUSs);
        }
        [HttpPost]

        public async Task<IActionResult> CreateRemoteUS([FromBody] CreateRemoteUS createRemoteUS)
        {
            var invalidNumUS = createRemoteUS.NumUSPickLists.Except(dataContext.USPickList.Select(u => u.NumUS)).ToList();
            if (invalidNumUS.Any())
            {
                throw new ArgumentException($"Les numéros de USPickList suivants sont invalides: {string.Join(",", invalidNumUS)}");
            }

            
            var entityToAdd = new RemoteUS()
            {
                NumPickList = createRemoteUS.NumPickList,
                MAPA = createRemoteUS.MAPA,
                OT = createRemoteUS.OT,
                EtatCreate = createRemoteUS.EtatCreate,
                EtatConfirm = createRemoteUS.EtatConfirm,
                DateCreation = DateTime.Now,
                DateMaj = null,
                Quantite = createRemoteUS.Quantite,
                ProduitCode = createRemoteUS.ProduitCode,
                Source = createRemoteUS.Source,
                USPickLists = new List<USPickList>()
            };

            foreach (var numUS in createRemoteUS.NumUSPickLists)
            {
                var usPickList = dataContext.USPickList.FirstOrDefault(u => u.NumUS == numUS);
                entityToAdd.USPickLists.Add(usPickList);
            }

            var createdRemoteUS = await remoteUSService.CreateRemoteUSAsync(entityToAdd);
            return Ok(createdRemoteUS);
        }
        


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRemoteUS(int id, [FromBody] UpdateRemoteUS updateRemoteUS)
        {
            var existingRemoteUS = await dataContext.RemoteUS.Include(r => r.USPickLists).FirstOrDefaultAsync(r => r.IdRemoteUS == id);

            if (existingRemoteUS == null)
            {
                // Gérer le cas où l'objet RemoteUS n'existe pas
                return NotFound();
            }

            var usPickListsToAdd = new List<USPickList>();
            foreach (var numUS in updateRemoteUS.NumUSPickLists)
            {
                var usPickList = await dataContext.USPickList.FirstOrDefaultAsync(u => u.NumUS == numUS);
                if (usPickList == null)
                {
                    // Gérer le cas où l'objet USPickList n'existe pas
                    return BadRequest($"Le numéro de USPickList '{numUS}' spécifié est invalide.");
                }
                usPickListsToAdd.Add(usPickList);
            }

            existingRemoteUS.NumPickList = updateRemoteUS.NumPickList;
            existingRemoteUS.MAPA = updateRemoteUS.MAPA;
            existingRemoteUS.OT = updateRemoteUS.OT;
            existingRemoteUS.EtatCreate = updateRemoteUS.EtatCreate;
            existingRemoteUS.EtatConfirm = updateRemoteUS.EtatConfirm;
            existingRemoteUS.DateMaj = DateTime.Now;
            existingRemoteUS.Quantite = updateRemoteUS.Quantite;
            existingRemoteUS.ProduitCode = updateRemoteUS.ProduitCode;
            existingRemoteUS.Source = updateRemoteUS.Source;
            existingRemoteUS.USPickLists = usPickListsToAdd;

            var updatedRemoteUS = await remoteUSService.UpdateRemoteUSAsync(existingRemoteUS);
            return Ok(updatedRemoteUS);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemoteUS(int id)
        {
            var remoteUS = await remoteUSService.GetRemoteUSAsync(id);
            if (remoteUS == null)
                return NotFound();
            var isSucces = await remoteUSService.DeleteRemoteUSAsync(id);
            return Ok();
        }
    }
}
