namespace TreeTrackerNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknown : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreeObservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TreeID = c.Int(nullable: false),
                        DateObserver = c.DateTime(nullable: false),
                        Watered = c.Boolean(nullable: false),
                        Fertalized = c.Boolean(nullable: false),
                        TrunkMeasurement = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Trees", t => t.TreeID, cascadeDelete: true)
                .Index(t => t.TreeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreeObservations", "TreeID", "dbo.Trees");
            DropIndex("dbo.TreeObservations", new[] { "TreeID" });
            DropTable("dbo.TreeObservations");
        }
    }
}
