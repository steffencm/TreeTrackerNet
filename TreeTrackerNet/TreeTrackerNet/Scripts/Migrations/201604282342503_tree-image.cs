namespace TreeTrackerNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class treeimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trees", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trees", "ImagePath");
        }
    }
}
