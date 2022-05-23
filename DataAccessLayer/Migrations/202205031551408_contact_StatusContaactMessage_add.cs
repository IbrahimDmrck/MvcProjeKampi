namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact_StatusContaactMessage_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "StatusContaactMessage", c => c.Boolean(nullable: false));
            DropColumn("dbo.Contacts", "MessageStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "MessageStatus", c => c.String());
            DropColumn("dbo.Contacts", "StatusContaactMessage");
        }
    }
}
