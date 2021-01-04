using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SRP.CustomReports.WPF.Entities
{
    public class Cluster
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string StageOfDevelopment { get; set; }

        public long RegionId { get; set; }

        [NotMapped]
        public string ShortName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    return Name;
                }

                const string pattern = "[^\\s]+\\s(.+)$";
                var matches = new Regex(pattern).Matches(Name);

                if (matches.Count == 1 && matches[0].Groups.Count == 2)
                {
                    return matches[0].Groups[1].Value;
                }

                return null;
            }
        }

        [NotMapped]
        public string ShortNameWithState
        {

            get
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    return Name;
                }

                const string pattern = "(\\w+)\\-[0-9A-Za-z]+ (.+)$";
                var matches = new Regex(pattern).Matches(Name);

                if (matches.Count == 1 && matches[0].Groups.Count == 3)
                {
                    return $"{matches[0].Groups[2].Value} ({matches[0].Groups[1].Value})";
                }

                return null;
            }
        }

    }
}
