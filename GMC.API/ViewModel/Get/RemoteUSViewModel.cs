using GMC.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMC.API.ViewModel.Get
{
    public class RemoteUSViewModel
    {
        public string NumPickList { get; set; }
        public string MAPA { get; set; }
        public int OT { get; set; }
        public int EtatCreate { get; set; }
        public int EtatConfirm { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateMaj { get; set; }
        public int Quantite { get; set; }
        public int ProduitCode { get; set; }
        public string Source { get; set; }
        public List<string> NumUSPickLists { get; set; }
    }
}
