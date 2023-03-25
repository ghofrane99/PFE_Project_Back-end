using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GMC.Core
{

    [Index(nameof(USPickList.NumUS), IsUnique = true)]
    public class USPickList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NumUS { get; set; }
        [JsonIgnore]
        public PickList PickList { get; set; }
        public int PickListId { get; set; }
        public int Quantite { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public string CodeProduit { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; }
        public DateTime? DateMaj { get; set; }

        public string Source { get; set; } = string.Empty;
        public string CreationPar { get; set; } = string.Empty;
        public string MajPar { get; set; } = string.Empty;
        [JsonIgnore]
        public InformationUS InformationUS { get; set; }
        [JsonIgnore]
        public List<RemoteUS> RemoteUSs { get; set; }



    }
}
