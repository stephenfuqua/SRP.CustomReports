using NUnit.Framework;
using Shouldly;
using SRP.CustomReports.WPF.Entities;

namespace SRP.CustomReports.Tests.Entities
{
    [TestFixture]
    public class ClusterTests
    {
        [TestCase("LA-131 River Parishes", "River Parishes")]
        [TestCase("OK-179 Woodward", "Woodward")]
        [TestCase("TX-263 Ellis - Navarro - Kaufman", "Ellis - Navarro - Kaufman")]
        [TestCase("TX-271C East Dallas County", "East Dallas County")]
        [TestCase("TX-311 San Antonio - Houston Corridor", "San Antonio - Houston Corridor")]
        public void GivenLongClusterName_ThenExtractNameWithoutCode(string fullName, string shortName)
        {
            var actual = (new Cluster { Name = fullName }).ShortName;

            actual.ShouldBe(shortName);
        }


        [TestCase("LA-131 River Parishes", "River Parishes (LA)")]
        [TestCase("OK-179 Woodward", "Woodward (OK)")]
        [TestCase("TX-263 Ellis - Navarro - Kaufman", "Ellis - Navarro - Kaufman (TX)")]
        [TestCase("TX-271C East Dallas County", "East Dallas County (TX)")]
        [TestCase("TX-311 San Antonio - Houston Corridor", "San Antonio - Houston Corridor (TX)")]
        public void GivenLongClusterName_ThenExtractNameStateAsSuffix(string fullName, string shortName)
        {
            var actual = (new Cluster { Name = fullName }).ShortNameWithState;

            actual.ShouldBe(shortName);
        }
    }
}
