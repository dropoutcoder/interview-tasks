﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DropoutCoder.CodingFun.SwapiAccess.Data {
    public class SwapiEntity {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}