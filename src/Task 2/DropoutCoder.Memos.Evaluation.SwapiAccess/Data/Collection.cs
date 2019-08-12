using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DropoutCoder.Memos.Evaluation.SwapiAccess.Data {
    public class Collection<T>
        where T : SwapiEntity {
        [JsonProperty("count")]
        public int Count {
            get;
            set;
        }

        [JsonProperty("next")]
        public Uri Next {
            get;
            set;
        }

        [JsonProperty("previous")]
        public Uri Previous {
            get;
            set;
        }

        [JsonProperty("results")]
        public IEnumerable<T> Results {
            get;
            set;
        }
    }
}