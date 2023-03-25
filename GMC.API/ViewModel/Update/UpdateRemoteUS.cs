using GMC.API.ViewModel.Get;

namespace GMC.API.ViewModel.Update
{
    public class UpdateRemoteUS 
    {
        public string NumPickList { get; set; }
        public string MAPA { get; set; }
        public int OT { get; set; }
        public int EtatCreate { get; set; }
        public int EtatConfirm { get; set; }
        public DateTime? DateMaj { get; set; }
        public int Quantite { get; set; }
        public int ProduitCode { get; set; }
        public string Source { get; set; }
        public List<string> NumUSPickLists { get; set; }
    }
}
