using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DropoutCoder.Memos.Evaluation.SwapiAccess.Data;
using Newtonsoft.Json;

namespace DropoutCoder.Memos.Evaluation.SwapiAccess.Http {
    public class SwapiClient {
        private readonly HttpClient _http = new HttpClient();

        private async Task<IEnumerable<T>> GetInternal<T>(string url)
            where T : SwapiEntity{
            var next = url;
            var results = new List<T>();

            do {
                var response = await _http.GetAsync(next);

                if (response.IsSuccessStatusCode) {
                    try {
                        var json = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Collection<T>>(json);

                        results.AddRange(result.Results);

                        next = result.Next?.AbsoluteUri;
                    } catch {
                        //  handle
                    }

                } else {
                    // handle
                }
            } while (next != null);

            return results;
        }


        public async Task<IEnumerable<Starship>> GetStarships() {
            var url = "https://swapi.co/api/starships/";

            return await GetInternal<Starship>(url);
        }

        public async Task<IEnumerable<Pilot>> GetPilots() {
            var url = "https://swapi.co/api/people/";

            return await GetInternal<Pilot>(url);
        }

        public async Task<IEnumerable<Planet>> GetPlanets() {
            var url = "https://swapi.co/api/planets/";

            return await GetInternal<Planet>(url);
        }
    }
}
