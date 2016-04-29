namespace TreeTrackerNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trees : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Trees", "Species", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trees", "Species", c => c.String());
            AlterColumn("dbo.Trees", "Name", c => c.String());
        }
    }
}
