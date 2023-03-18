using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GMC.Core
{
    public class Status
    {

        [Key]
        public int IdStatus { get; set; }
        public string Code { get; set; } = string.Empty;
        [JsonIgnore]
        public List<PickList> PickLists { get; set; }
        [JsonIgnore]
        public List<DetailPickList> DetailPickLists { get; set; }
        [JsonIgnore]
        public List<USPickList> USPickLists { get; set; }
    }
}
