using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class PickListDTO
    {
        public int IdPickList { get; set; }
        public string NumPickList { get; set; }
        public string Magasin { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateMaj { get; set; }
        public string TypePickList { get; set; }
        public string CodeProduit { get; set; }
        public DateTime? DateLivraison { get; set; }
        public DateTime? DateServi { get; set; }
        public int? NbUSServi { get; set; }
        public int? NbUSRecept { get; set; }
        public string Observation { get; set; }
        public int? IdCauseServi { get; set; }
        public int? PrintedServi { get; set; }
        public string DemandeAnnulation { get; set; }
        public string DemandeSuppPar { get; set; }
        public string ApprobSuppPar { get; set; }
        public DateTime? DateDemandeSuppression { get; set; }
        public DateTime? DateApprobSuppression { get; set; }
        public int? NbUSReceptCond { get; set; }
        public string SetEmp { get; set; }
        public string CodeLigneProduction { get; set; }
        public string Code { get; set; }
        public string CreerPar { get; set; }

        public int LigneProductionId { get; set; }
        public int StatusId { get; set; }

    }
}
