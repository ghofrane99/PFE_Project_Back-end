using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class DetailPickListDTO
    {
        public int IdDetailPickList { get; set; }
        public string PickList { get; set; }
        public int Produit { get; set; }
        public string Emplacement { get; set; }
        public int QuantiteDemande { get; set; }
        public string Status { get; set; }
        public int? NombreUS { get; set; }
        public int? Skipped { get; set; }
        public int PickListId { get; set; }
        public int ProduitId { get; set; }
        public int StatusId { get; set; }


    }
}
