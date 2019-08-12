using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DropoutCoder.Memos.Evaluation.SwapiAccess.Data {
    public class Planet: SwapiEntity {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
