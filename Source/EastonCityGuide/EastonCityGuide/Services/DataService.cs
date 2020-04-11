using System.Collections.Generic;
using System.Linq;
using EastonCityGuide.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using EastonCityGuide.Services;

namespace EastonCityGuide.Services
{
    public static class DataService
    {
        public static List<string> Routing { get; } = new List<string>
        {
            "Center Square",
            "Christopher Columbus Statue",
            "Cottingham Stadium",
            "EastonAreaHighSchool",
            "Easton-PBurg Bridge",
            "Easton Public Library",
            "Easton Public Market",
            "Karl Stirner Arts Trail",
            "Larry Holmes Statue",
            "NorthHampton County Court House",
            "Nurture Nature Center",
            "Paxinosa Elementary School",
            "RiverSide Park",
            "Sigal Museum",
            "State Theatre",
            "Vietnam Memorial",
            "Wilson Area High School",
        };
        public static List<Location> Coordinates { get; } = new List<Location>
        {
            new Location(40.691216, -75.209130),
            new Location(40.692109, -75.205205),
            new Location(40.691737, -75.225713),
            new Location(40.682571, -75.252674),
            new Location(40.694538, -75.203715),
            new Location(40.691944, -75.213611),
            new Location(40.691281, -75.210421),
            new Location(40.696192, -75.228143),
            new Location(40.689864, -75.205397),
            new Location(40.687306, -75.217623),
            new Location(40.690585, -75.213675),
            new Location(40.690811, -75.227308),
            new Location(40.692191, -75.205048),
            new Location(40.690848, -75.210674),
            new Location(40.691389, -75.212500),
            new Location(40.682574, -75.250029),
            new Location(40.684204, -75.243630),
        };
        public static List<string> Places { get; } = new List<string>
        {
           "Center Square",
           "Center",
           "Square",

           "Christopher Columbus Statue",
           "Christopher Columbus",
           "Christopher",
           "Columbus",

           "Cottingham Stadium",
           "Cottingham",

           "EastonAreaHighSchool",
           "EastonHighSchool",
           "EastonHS",
           "EastonSchool",

           "Easton-PBurg Bridge",
           "Bridge",

           "Easton Public Library",
           "Library",

           "Easton Public Market",
           "Market",

           "Karl Stirner Arts Trail",
           "KarlStirnerArtsTrail",
           "Arts Trail",
           "ArtsTrail",

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

           "Paxinosa Elementary School",
           "PaxinosaElementarySchool",
           "Paxinosa",

           "RiverSide Park",
           "RiverSide",

           "Sigal Museum",
           "Sigal",

           "State Theatre",
           "Theatre",

           "Vietnam Memorial",
           "VietnamMemorial",
           "Memorial",
           "Vietnam",

           "Wilson Area High School",
           "WilsonAreaHighSchool",
           "WilsonHighSchool",
           "WilsonHS",
           "Wilson",
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

            new Position(40.691737, -75.225713),
            new Position(40.691737, -75.225713),

            new Position(40.682571, -75.252674),
            new Position(40.682571, -75.252674),
            new Position(40.682571, -75.252674),
            new Position(40.682571, -75.252674),

            new Position(40.694538, -75.203715),
            new Position(40.694538, -75.203715),

            new Position(40.691944, -75.213611),
            new Position(40.691944, -75.213611),

            new Position(40.691281, -75.210421),
            new Position(40.691281, -75.210421),

            new Position(40.696192, -75.228143),
            new Position(40.696192, -75.228143),
            new Position(40.696192, -75.228143),
            new Position(40.696192, -75.228143),

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

            new Position(40.690811, -75.227308),
            new Position(40.690811, -75.227308),
            new Position(40.690811, -75.227308),

            new Position(40.692191, -75.205048),
            new Position(40.692191, -75.205048),

            new Position(40.690848, -75.210674),
            new Position(40.690848, -75.210674),

            new Position(40.691389, -75.212500),
            new Position(40.691389, -75.212500),

            new Position(40.682574, -75.250029),
            new Position(40.682574, -75.250029),
            new Position(40.682574, -75.250029),
            new Position(40.682574, -75.250029),

            new Position(40.684204, -75.243630),
            new Position(40.684204, -75.243630),
            new Position(40.684204, -75.243630),
            new Position(40.684204, -75.243630),
            new Position(40.684204, -75.243630),
        };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Places.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }
    }
}
