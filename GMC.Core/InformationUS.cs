using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class InformationUS
    {
        [Key]
        public int IdInformationUS { get; set; }


        [ForeignKey("USPickList")]
        public string NumUs { get; set; }
        public USPickList USPickList { get; set; }
        public string CodeProduit { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public int StockSpecial { get; set; }
        public string Fournisseur { get; set; } = string.Empty;
        public string SAPMag { get; set; } = string.Empty;
        public string Emplacement { get; set; } = string.Empty;
        public string RefLotFRS { get; set; } = string.Empty;
        public int DateCodeSAG { get; set; }
        public int AvisArrivage { get; set; }
        public string Fabricant { get; set; } = string.Empty;
        public string CodePart { get; set; } = string.Empty;
        public string RefFabricant { get; set; } = string.Empty;
        public int CodeCoutStock { get; set; }
        public int NumPieceFab { get; set; }
    }
}
