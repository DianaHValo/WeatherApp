using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp
{
    public class clouds
    {
        [JsonProperty("all")]
        public string All { get; set; }
    }
}
