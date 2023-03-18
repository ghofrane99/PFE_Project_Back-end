using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GMC.Core
{
    public class RemoteUS
    {
        [Key]
        public int IdRemoteUS { get; set; }
        public string NumPickList { get; set; }
        public string MAPA { get; set; } = string.Empty;
        public int OT { get; set; }
        public int EtatCreate { get; set; }
        public int EtatConfirm { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public int Quantite { get; set; }
        public int ProduitCode { get; set; }
        public string Source { get; set; } = string.Empty;
        public string Hostanme { get; set; } = string.Empty;
        public List<USPickList> USPickLists { get; set; }
       
    }
}
