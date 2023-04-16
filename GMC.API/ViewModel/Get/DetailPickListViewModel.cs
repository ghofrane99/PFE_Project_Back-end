using GMC.Core;

namespace GMC.API.ViewModel.Get
{
    public class DetailPickListViewModel
    {
        public int PickListId { get; set; }
        public int ProduitId { get; set; }
        public string? Emplacement { get; set; }
        public int QuantiteDemande { get; set; }
        public int StatusId { get; set; }
        public int? NombreUS { get; set; }
        public int? Skipped { get; set; }
    }
}
