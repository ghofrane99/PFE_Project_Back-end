using GMC.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMC.API.ViewModel.Get
{
    public class USPickListViewModel
    {
        public string NumUS { get; set; }
        public int PickListId { get; set; }
        public int Quantite { get; set; }
        public int StatusId { get; set; }
        public string CodeProduit { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public string Hostname { get; set; }
        public string Source { get; set; }
        public string CreationPar { get; set; }
        public string MajPar { get; set; }
    }
}
