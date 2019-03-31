using System.Collections.Generic;
using System.Text;

namespace SRP.CustomReports.WPF.Entities
{
    public class YouthContinuum
    {
        public string Individual { get; set; }

        public string Locality { get; set; }

        public string ClusterName { get; set; }

        public int YIC { get; set; }

        public int YEI { get; set; }

        public int YCA { get; set; }

        public int YAO { get; set; }

        public int AttendedCC { get; set; }

        public int TaughtCC { get; set; }

        public int AttendedJYG { get; set; }

        public int AnimatedJYG { get; set; }

        public int AttendedSC { get; set; }

        public int TutoredSC { get; set; }


        public override string ToString()
        {
            return
                $"{Individual}, {Locality}, {ClusterName}, {YIC}, {YEI}, {YCA}, {YAO}, {AttendedCC}, {TaughtCC}, {AttendedJYG}, {AnimatedJYG}, {AttendedSC}, {TutoredSC}";
        }

        public static string ListToString(IEnumerable<YouthContinuum> list)
        {
            var builder = new StringBuilder();
            builder.AppendLine(
                $"{nameof(Individual)}, {nameof(Locality)}, {nameof(ClusterName)}, {nameof(YIC)}, {nameof(YEI)}, {nameof(YCA)}, {nameof(YAO)}, {nameof(AttendedCC)}, {nameof(TaughtCC)}, {nameof(AttendedJYG)}, {nameof(AnimatedJYG)}, {nameof(AttendedSC)}, {nameof(TutoredSC)}");

            foreach (var youth in list)
            {
                builder.AppendLine(youth.ToString());
            }

            return builder.ToString();
        }
    }
}
