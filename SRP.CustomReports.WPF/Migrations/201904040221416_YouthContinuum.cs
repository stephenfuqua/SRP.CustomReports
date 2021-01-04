using SRP.CustomReports.WPF.Migrations.Customization;
using SRP.CustomReports.WPF.Migrations.Views;
    using System.Data.Entity.Migrations;

namespace SRP.CustomReports.WPF.Migrations
{
    public partial class YouthContinuum : DbMigration
    {
        const string ViewName = "YouthContinuum";

        public override void Up()
        {
            var viewDefinition = ViewFile.Read(ViewName);

            this.CreateView(ViewName, viewDefinition);
        }

        public override void Down()
        {
            this.DropView(ViewName);
        }
    }
}
