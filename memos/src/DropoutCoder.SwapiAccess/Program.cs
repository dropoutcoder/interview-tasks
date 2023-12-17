using System;
using System.Linq;
using System.Threading.Tasks;
using DropoutCoder.CodingFun.SwapiAccess.Http;

namespace DropoutCoder.CodingFun.SwapiAccess {
    class Program {
        static async Task Main(string[] args) {
            var client = new SwapiClient();

            var starships = await client.GetStarships();

            var pilots = await client.GetPilots();

            var planets = await client.GetPlanets();

            var kashyyk = planets.Single(p => p.Name == "Kashyyyk");

            var kashyyykPilots = pilots
                .Where(p => p.Homeworld == kashyyk.Url)
                .Select(p=> p.Url);

            var result = starships.Where(s => s.Pilots.Any(p => kashyyykPilots.Contains(p)));
        }
    }
}
