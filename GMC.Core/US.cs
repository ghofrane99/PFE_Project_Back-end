using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GMC.Core
{
    [Index(nameof(USPickList.NumUS), IsUnique = true)]
    public class US
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NumUS { get; set; }
        public string CodeProduit { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public string RefLotFRS { get; set; } = string.Empty;
        public int DateCodeSAG { get; set; }
        public int StockSpecial { get; set; }
        public string SAPMag { get; set; } = string.Empty;
    }
}
