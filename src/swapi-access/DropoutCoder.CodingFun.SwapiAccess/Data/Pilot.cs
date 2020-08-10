using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DropoutCoder.CodingFun.SwapiAccess.Data {
    public class Pilot : SwapiEntity {
        [JsonProperty("homeworld")]
        public string Homeworld {
            get; set;
        }
    }
}
