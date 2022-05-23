namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_about_age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "age");
        }
    }
}
