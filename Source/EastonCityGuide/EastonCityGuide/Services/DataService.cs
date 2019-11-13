using System.Collections.Generic;
using System.Linq;

namespace EastonCityGuide.Services
{
    public static class DataService
    {
        public static List<string> Places { get; } = new List<string>
        {
           "Center Square",
           "Christopher Columbus Statue",
           "Easton-PBurg Bridge",
           "Easton Public Libary",
           "Easton Public Market",
           "Larry Holmes Statue",
           "NorthHampton County Court House",
           "Nurture Nature Center",
           "RiverSide Park",
           "Sigal Museum",
           "State Theater"
        };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Places.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }
    }
}
