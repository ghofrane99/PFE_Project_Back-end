using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }
        public int CodeProduit { get; set; }
        public int Seuil { get; set; }
        public int Etat { get; set; }
        public int Preparateur { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public string Designation { get; set; } = string.Empty;
        public string Hostname { get; set; } = string.Empty;

        [JsonIgnore]
        public List<DetailPickList> DetailPickLists { get; set; }
    }
}
