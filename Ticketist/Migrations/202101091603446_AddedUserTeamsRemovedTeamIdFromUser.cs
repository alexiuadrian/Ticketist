namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserTeamsRemovedTeamIdFromUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTeams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "TeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "TeamId", c => c.Int(nullable: false));
            DropTable("dbo.UserTeams");
        }
    }
}
