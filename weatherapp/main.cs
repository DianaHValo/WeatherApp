using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp
{
    public class main
    {
        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }
        [JsonProperty("temp")]
        public string Temp { get; set; }
    }

}
