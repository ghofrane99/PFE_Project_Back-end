using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GMC.Core
{
    public class DetailPickList
    {
        [Key]
        public int IdPickDetail { get; set; }
        [JsonIgnore]
        public PickList PickList { get; set; }
        public int PickListId { get; set; }
        [JsonIgnore]
        public Produit Produit { get; set; }
        public int ProduitId { get; set; }
        public string? Emplacement { get; set; } = string.Empty;
        public int QuantiteDemande { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public int? NombreUS { get; set; }
        public int? Skipped { get; set; }
    }
}
