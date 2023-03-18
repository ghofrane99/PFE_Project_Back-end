namespace GMC.API.ViewModel.Get
{
    public class ProduitViewModel
    {
        public int CodeProduit { get; set; }
        public int Seuil { get; set; }
        public int Etat { get; set; }
        public int Preparateur { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public string Designation { get; set; }
        public string Hostname { get; set; }
    }
}
