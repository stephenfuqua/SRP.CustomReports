using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SRP.CustomReports.WPF.Entities
{
    [Table("YouthContinuum")]
    public class YouthContinuum
    {
        [Key]
        public long Id { get; set; }

        public string Individual { get; set; }

        public string Locality { get; set; }

        public string ClusterName { get; set; }

        public long ClusterId { get; set; }

        public string GroupName { get; set; }

        public int GroupId { get; set; }
        

        [Column("YIC")]
        public int YouthInConversation { get; set; }

        [Column("YEI")]
        public int YouthEnteredInstitute { get; set; }

        [Column("YCA")]
        public int YouthCarryingOutActivities { get; set; }

        [Column("YAO")]
        public int YouthAccompanyingOthers { get; set; }

        [Column("AttendedCC")]
        public int AttendedChildrensClass { get; set; }

        [Column("TaughtCC")]
        public int TaughtChildrensClass { get; set; }

        [Column("AttendedJYG")]
        public int AttendedJuniorYouthGroup { get; set; }

        [Column("AnimatedJYG")]
        public int AnimatedJuniorYouthGroup { get; set; }

        [Column("AttendedSC")]
        public int AttendedStudyCircle { get; set; }

        [Column("TutoredSC")]
        public int TutoredStudyCircle { get; set; }


        public override string ToString()
        {
            return
                $"{Individual}, {Locality}, {ClusterName}, {GroupName}, {YouthInConversation}, {YouthEnteredInstitute}, {YouthCarryingOutActivities}, {YouthAccompanyingOthers}, {AttendedChildrensClass}, {TaughtChildrensClass}, {AttendedJuniorYouthGroup}, {AnimatedJuniorYouthGroup}, {AttendedStudyCircle}, {TutoredStudyCircle}";
        }

        public static string ListToString(IEnumerable<YouthContinuum> list)
        {
            var builder = new StringBuilder();
            builder.AppendLine(
                $"{nameof(Individual)}, {nameof(Locality)}, {nameof(ClusterName)}, {nameof(GroupName)} {nameof(YouthInConversation)}, {nameof(YouthEnteredInstitute)}, {nameof(YouthCarryingOutActivities)}, {nameof(YouthAccompanyingOthers)}, {nameof(AttendedChildrensClass)}, {nameof(TaughtChildrensClass)}, {nameof(AttendedJuniorYouthGroup)}, {nameof(AnimatedJuniorYouthGroup)}, {nameof(AttendedStudyCircle)}, {nameof(TutoredStudyCircle)}");

            foreach (var youth in list)
            {
                builder.AppendLine(youth.ToString());
            }

            return builder.ToString();
        }
    }
}
