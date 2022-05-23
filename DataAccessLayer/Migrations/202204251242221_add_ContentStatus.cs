namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ContentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContenStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContenStatus");
        }
    }
}
