namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserTeamsIdToInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserTeams");
            AlterColumn("dbo.UserTeams", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserTeams", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserTeams");
            AlterColumn("dbo.UserTeams", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserTeams", "Id");
        }
    }
}
