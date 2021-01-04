using SRP.CustomReports.WPF.Entities;
using SRP.CustomReports.WPF.Queries;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SRP.CustomReports.WPF.Migrations
{
    public static class InitializeGroupings
    {

        public class TemporaryClusterGrouping
        {
            public string GroupName { get; set; }
            public string Reservoir { get; set; }
            public List<string> Clusters { get; set; }

            public TemporaryClusterGrouping(string groupName, string reservoir, params string[] clusters)
            {
                GroupName = groupName;
                Reservoir = reservoir;
                Clusters = clusters.ToList();
            }
        }

        public static void InstallGroupings(SrpContext db)
        {
            var clusters = db.Clusters.ToList().ToDictionary(x => x.ShortName, x => x);

            var clusterGroupingList = new List<TemporaryClusterGrouping>
            {
                new TemporaryClusterGrouping("Arkansas", "Little Rock Area",
                    "Springdale Area",
                    "Little Rock Area",
                    "Fort Smith Area",
                    "Boone-Searcy",
                    "McAlester",
                    "River Valley",
                    "Pine Bluff Area",
                    "Hot Springs Area"),
                new TemporaryClusterGrouping("Austin", "Austin Area",
                    "Austin Area",
                    "Greater Williamson County",
                    "Hays County",
                    "Hill Country Central",
                    "Hill Country North",
                    "San Antonio-Houston Corridor",
                    "Bastrop County"),
                new TemporaryClusterGrouping("Dallas", "Dallas City",
                    "Dallas City",
                    "Tyler Area",
                    "Northeast Dallas County",
                    "East Dallas County",
                    "Amarillo Area",
                    "Ellis-Navarro-Kaufman",
                    "Rockwall County",
                    "East Texas",
                    "Far East North Texas",
                    "Lubbock Area"),
                new TemporaryClusterGrouping("Harris", "Harris County Central",
                    "Harris County East",
                    "Harris County West",
                    "Bryan-College Station",
                    "Port Arthur-Beaumont Area",
                    "East Texas Hilly",
                    "Liberty-Hardin",
                    "Gulf Coast",
                    "Fort Bend-Brazoria",
                    "Montgomery County",
                    "Harris County Central"),
                new TemporaryClusterGrouping("Louisiana", "New Orleans Area",
                    "New Orleans Area",
                    "Baton Rouge Area",
                    "River Parishes",
                    "North Shore-Lake Pontchartrain",
                    "Houma Area",
                    "Lafayette Area",
                    "Lake Charles Area",
                    "Alexandria Area",
                    "Shreveport Area"),
                new TemporaryClusterGrouping("Metrocrest", "Metrocrest",
                    "Metrocrest",
                    "Plano City",
                    "East Collin",
                    "West Collin",
                    "Denton County South",
                    "Denton County North",
                    "Texoma Lake",
                    "Wichita Falls Area"),
                new TemporaryClusterGrouping("Northeast Tarrant", "Northeast Tarrant County",
                    "Northeast Tarrant County",
                    "Arlington Mid-Cities",
                    "Fort Worth City",
                    "Southwest Dallas County",
                    "Waco Area",
                    "Trans West Corridor",
                    "Andrews-Crane",
                    "North Central",
                    "Martin-Crockett"
                    ),
                new TemporaryClusterGrouping("Oklahoma", "Oklahoma City",
                    "Oklahoma City",
                    "Norman",
                    "Enid",
                    "Muskogee",
                    "Tulsa",
                    "Stillwater",
                    "El Reno"),
                new TemporaryClusterGrouping("San Antonio", "San Antonio Area",
                    "San Antonio Area",
                    "El Paso Area",
                    "Rio Grande Valley",
                    "Laredo Border",
                    "Valverde-Zavala",
                    "Victoria Area",
                    "Corpus Christi Area")
            };


            foreach (var cg in clusterGroupingList)
            {
                var grouping = new Grouping
                {
                    GroupName = cg.GroupName,
                    ReservoirClusterId = clusters.GetValueFor(cg.Reservoir)?.Id
                };
                db.Groupings.AddOrUpdate(grouping);
                db.SaveChanges();

                foreach (var c in cg.Clusters)
                {
                    var cluster = clusters.GetValueFor(c);
                    if (cluster == null) continue;

                    var a = new ClusterGrouping
                    {
                        Cluster = cluster,
                        Grouping = grouping
                    };
                    db.ClusterGroupings.AddOrUpdate(a);
                    db.SaveChanges();
                }
            }
        }


        private static T GetValueFor<T>(this Dictionary<string, T> dictionary, string key)
            where T : class
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }

            return null;
        }
    }
}
