using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DropoutCoder.SwapiAccess.Data
{
    public class Starship : SwapiEntity
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("model")]
        public string Model
        {
            get;
            set;
        }

        [JsonProperty("manufacturer")]
        public string Manufacturer
        {
            get;
            set;
        }

        [JsonProperty("cost_in_credits")]
        public string Price
        {
            get;
            set;
        }

        [JsonProperty("length")]
        public string Length
        {
            get;
            set;
        }

        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmosphericSpeed
        {
            get;
            set;
        }

        [JsonProperty("crew")]
        public string Crew
        {
            get;
            set;
        }

        [JsonProperty("passengers")]
        public string Passengers
        {
            get;
            set;
        }

        [JsonProperty("cargo_capacity")]
        public string CargoCapacity
        {
            get;
            set;
        }

        [JsonProperty("consumables")]
        public string Consumables
        {
            get;
            set;
        }

        [JsonProperty("pilots")]
        public IEnumerable<string> Pilots
        {
            get; set;
        }

        [JsonProperty("films")]
        public IEnumerable<string> Movies
        {
            get; set;
        }

        [JsonProperty("starship_class")]
        public string Class
        {
            get;
            set;
        }

        [JsonProperty("hyperdrive_rating")]
        public string HyperdriveRating
        {
            get;
            set;
        }

        [JsonProperty("MGLT")]
        public string MaxMegaLightsSpeed
        {
            get;
            set;
        }
    }
}