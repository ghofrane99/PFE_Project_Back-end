using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class PickList
    {
        [Key]
        public int IdPickList { get; set; }
        public string? NumPickList { get; set; } = string.Empty;
        public string? Magasin { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; }
        public DateTime? DateMaj { get; set; }
        public string? TypePickList { get; set; } = string.Empty;
        public string? CodeProduit { get; set; } = string.Empty;
        public DateTime? DateLivraison { get; set; }
        public DateTime? DateServi { get; set; }
        public int? NbUSServi { get; set; }
        public int? NbUSRecept { get; set; }
        public string? Observation { get; set; } = string.Empty;
        public int? IdCauseServi { get; set; }
        public int? PrintedServi { get; set; }
        public string? DemandeAnnulation { get; set; } = string.Empty;
        public string? DemandeSuppPar { get; set; } = string.Empty;
        public string? ApprobSuppPar { get; set; } = string.Empty;
        public DateTime? DateDemandeSuppression { get; set; }
        public DateTime? DateApprobSuppression { get; set; }
        public int? NbUSReceptCond { get; set; }
        public string? CreerPar { get; set; } = string.Empty;
        public string? SetEmp { get; set; } = string.Empty;
        [JsonIgnore]
        public LigneProduction LigneProduction { get; set; }
        public int LigneProductionId { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        [JsonIgnore]
        public List<DetailPickList> DetailPickLists { get; set; }
        [JsonIgnore]
        public List<USPickList> USPickLists { get; set; }

    }
}
