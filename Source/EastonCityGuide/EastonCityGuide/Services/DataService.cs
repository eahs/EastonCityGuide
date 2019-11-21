using System.Collections.Generic;
using System.Linq;
using EastonCityGuide.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using EastonCityGuide.Services;

namespace EastonCityGuide.Services
{
    public static class DataService
    {
        public static List<string> Places { get; } = new List<string>
        {
           "Center Square",
           "Center",
           "Square",

           "Christopher Columbus Statue",
           "Christopher Columbus",
           "Christopher",
           "Columbus",

           "Easton-PBurg Bridge",
           "Bridge",

           "Easton Public Library",
           "Library",

           "Easton Public Market",
           "Market",

           "Larry Holmes Statue",
           "Larry Holmes",
           "Larry",
           "Holmes",

           "NorthHampton County Court House",
           "Court House",
           "Court",

           "Nurture Nature Center",
           "Nurture Nature",
           "Nature Center",

           "RiverSide Park",
           "RiverSide",

           "Sigal Museum",
           "Sigal",

           "State Theater",
           "Theater"
        };

        public static List<Position> Locations { get; } = new List<Position>
        {
            new Position(40.691216, -75.209130),
            new Position(40.691216, -75.209130),
            new Position(40.691216, -75.209130),

            new Position(40.692109, -75.205205),
            new Position(40.692109, -75.205205),
            new Position(40.692109, -75.205205),
            new Position(40.692109, -75.205205),

            new Position(40.694538, -75.203715),
            new Position(40.694538, -75.203715),

            new Position(40.691944, -75.213611),
            new Position(40.691944, -75.213611),

            new Position(40.691281, -75.210421),
            new Position(40.691281, -75.210421),

            new Position(40.689864, -75.205397),
            new Position(40.689864, -75.205397),
            new Position(40.689864, -75.205397),
            new Position(40.689864, -75.205397),

            new Position(40.687306, -75.217623),
            new Position(40.687306, -75.217623),
            new Position(40.687306, -75.217623),

            new Position(40.690585, -75.213675),
            new Position(40.690585, -75.213675),
            new Position(40.690585, -75.213675),

            new Position(40.692191, -75.205048),
            new Position(40.692191, -75.205048),

            new Position(40.690848, -75.210674),
            new Position(40.690848, -75.210674),

            new Position(40.691389, -75.212500),
            new Position(40.691389, -75.212500)
        };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Places.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }
    }
}
