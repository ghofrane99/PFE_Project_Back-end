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
    public class InformationUSController : ControllerBase
    {
        private readonly IInformationUSService informationUSService;
        public InformationUSController(IInformationUSService informationUSService)
        {
            this.informationUSService = informationUSService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInformationUS()
        {

            var informationUSs = await informationUSService.GetInformationUSsAsync();
            return Ok(informationUSs);
        }

        [HttpPost]
        public async Task<IActionResult> CreatInformationUS([FromBody] CreateInformationUS createInformationUS)
        {
            var entityToAdd = new InformationUS()
            {
                NumUs = createInformationUS.NumUs,
                CodeProduit = createInformationUS.CodeProduit,
                Quantite = createInformationUS.Quantite,
                StockSpecial = createInformationUS.StockSpecial,
                Fournisseur = createInformationUS.Fournisseur,
                SAPMag = createInformationUS.SAPMag,
                Emplacement = createInformationUS.Emplacement,
                RefLotFRS = createInformationUS.RefLotFRS,
                DateCodeSAG = createInformationUS.DateCodeSAG,
                AvisArrivage = createInformationUS.AvisArrivage,
                Fabricant = createInformationUS.Fabricant,
                CodePart = createInformationUS.CodePart,
                RefFabricant = createInformationUS.RefFabricant,
                CodeCoutStock = createInformationUS.CodeCoutStock,
                NumPieceFab = createInformationUS.NumPieceFab,



            };

            var createdInformationUS = await informationUSService.CreateInformationUSAsync(entityToAdd);
            return Ok(createdInformationUS);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatInformationUS(int id, [FromBody] UpdateInformationUS updateInformationUS)
        {
            var entityToUpdate = await informationUSService.GetInformationUSAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound();
            }
            entityToUpdate.NumUs = updateInformationUS.NumUs;
            entityToUpdate.CodeProduit = updateInformationUS.CodeProduit;
            entityToUpdate.Quantite = updateInformationUS.Quantite;
            entityToUpdate.StockSpecial = updateInformationUS.StockSpecial;
            entityToUpdate.Fournisseur = updateInformationUS.Fournisseur;
            entityToUpdate.SAPMag = updateInformationUS.SAPMag;
            entityToUpdate.Emplacement = updateInformationUS.Emplacement;
            entityToUpdate.RefLotFRS = updateInformationUS.RefLotFRS;
            entityToUpdate.DateCodeSAG = updateInformationUS.DateCodeSAG;
            entityToUpdate.AvisArrivage = updateInformationUS.AvisArrivage;
            entityToUpdate.Fabricant = updateInformationUS.Fabricant;
            entityToUpdate.CodePart = updateInformationUS.CodePart;
            entityToUpdate.RefFabricant = updateInformationUS.RefFabricant;
            entityToUpdate.CodeCoutStock = updateInformationUS.CodeCoutStock;
            entityToUpdate.NumPieceFab = updateInformationUS.NumPieceFab;






            var updatedInformationUS = await informationUSService.UpdateInformationUSAsync(entityToUpdate);
            return Ok(updatedInformationUS);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformationUS(int id)
        {
            var informationUS = await informationUSService.GetInformationUSAsync(id);
            if (informationUS == null)
                return NotFound();
            var isSucces = await informationUSService.DeleteInformationUSAsync(id);
            return Ok();
        }
    }
}
