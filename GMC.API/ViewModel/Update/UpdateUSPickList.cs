namespace GMC.API.ViewModel.Update
{
    public class UpdateUSPickList
    {

        public int PickListId { get; set; }
        public int Quantite { get; set; }
        public int StatusId { get; set; }
        public string CodeProduit { get; set; }
        public DateTime? DateMaj { get; set; }
        public string Source { get; set; }
        public string CreationPar { get; set; }
        public string MajPar { get; set; }
    }
}
