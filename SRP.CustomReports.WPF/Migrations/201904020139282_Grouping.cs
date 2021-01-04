namespace SRP.CustomReports.WPF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class GroupingMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClusterGroupings",
                c => new
                    {
                        ClusterId = c.Long(nullable: false),
                        GroupingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClusterId, t.GroupingId })
                .ForeignKey("dbo.Clusters", t => t.ClusterId, cascadeDelete: true)
                .ForeignKey("dbo.Groupings", t => t.GroupingId, cascadeDelete: true)
                .Index(t => t.ClusterId)
                .Index(t => t.GroupingId);
            
            
            CreateTable(
                "dbo.Groupings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(maxLength: 50),
                        ReservoirClusterId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clusters", t => t.ReservoirClusterId)
                .Index(t => t.ReservoirClusterId)
                .Index(t => t.GroupName, "IX_Groupings_GroupName");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClusterGroupings", "GroupingId", "dbo.Groupings");
            DropForeignKey("dbo.Groupings", "ReservoirClusterId", "dbo.Clusters");
            DropForeignKey("dbo.ClusterGroupings", "ClusterId", "dbo.Clusters");
            DropIndex("dbo.Groupings", new[] { "ReservoirClusterId" });
            DropIndex("dbo.ClusterGroupings", new[] { "GroupingId" });
            DropIndex("dbo.ClusterGroupings", new[] { "ClusterId" });
            DropTable("dbo.Groupings");
            DropTable("dbo.ClusterGroupings");
        }
    }
}
