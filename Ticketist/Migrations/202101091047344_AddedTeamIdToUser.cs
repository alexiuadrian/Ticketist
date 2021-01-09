namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamIdToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TeamId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TeamId");
        }
    }
}
