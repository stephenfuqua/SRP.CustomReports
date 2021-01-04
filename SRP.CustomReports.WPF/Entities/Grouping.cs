using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRP.CustomReports.WPF.Entities
{
    public class Grouping
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; }

        public long? ReservoirClusterId { get; set; }

        [ForeignKey(nameof(ReservoirClusterId))]
        public Cluster ReservoirCluster { get; set; }
    }
}
