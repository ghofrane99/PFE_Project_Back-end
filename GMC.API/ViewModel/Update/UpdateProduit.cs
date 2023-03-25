using GMC.API.ViewModel.Get;

namespace GMC.API.ViewModel.Update
{
    public class UpdateProduit 
    {
        public int CodeProduit { get; set; }
        public int Seuil { get; set; }
        public int Etat { get; set; }
        public DateTime? DateMaj { get; set; }
        public string Designation { get; set; }
        public string CreerPar { get; set; }
    }
}
