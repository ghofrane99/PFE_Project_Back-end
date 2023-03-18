using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class LigneProduction
    {
        [Key]
        public int IdLigneProduction { get; set; }
        public string CodeLigneProduction { get; set; } = string.Empty;
        public int Etat { get; set; }
        public string Observation { get; set; } = string.Empty;
        public string RobotTraitement { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; }
        public DateTime DateMaj { get; set; }
        public string Hostname { get; set; } = string.Empty;
        public int Boucle { get; set; }
        public int Forced { get; set; }
        public int ProduitForced { get; set; }
        [JsonIgnore]
        public List<PickList> PickLists { get; set; }
    }
}
