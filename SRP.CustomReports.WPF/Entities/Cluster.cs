using System.ComponentModel.DataAnnotations;

namespace SRP.CustomReports.WPF.Entities
{
    public class Cluster
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string StageOfDevelopment { get; set; }

        public long RegionId { get; set; }

    }
}
