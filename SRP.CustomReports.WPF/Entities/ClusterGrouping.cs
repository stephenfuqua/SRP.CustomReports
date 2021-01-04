using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRP.CustomReports.WPF.Entities
{
    public class ClusterGrouping
    {
        [Key, Column(Order=0)]
        public long ClusterId { get; set; }

        [Key, Column(Order = 1)]
        public int GroupingId { get; set; }

        [ForeignKey(nameof(ClusterId))]
        public Cluster Cluster { get; set; }

        [ForeignKey(nameof(GroupingId))]
        public Grouping Grouping { get; set; }
    }
}
