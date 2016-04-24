namespace TreeTrackerNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AquiredFrom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trees", "AquiredFrom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trees", "AquiredFrom");
        }
    }
}
