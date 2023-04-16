using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class USPickListDTO
    {
        public string NumUS { get; set; }
        public string PickList { get; set; }
        public int PickListId { get; set; }
        public int Quantite { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public string CodeProduit { get; set; } 
        public DateTime DateCreation { get; set; }
        public DateTime? DateMaj { get; set; }
        public string Source { get; set; } 
        public string CreationPar { get; set; }
        public string MajPar { get; set; } 
    }
}
