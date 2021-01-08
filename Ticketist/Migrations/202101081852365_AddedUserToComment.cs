namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "User", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "User");
        }
    }
}
