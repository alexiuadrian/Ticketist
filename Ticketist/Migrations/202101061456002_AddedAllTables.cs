namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAllTables : DbMigration
    {
        public override void Up()
        { 
            Sql("INSERT INTO Status (Name) VALUES ('IN PROGRESS')");
            Sql("INSERT INTO Status (Name) VALUES ('DONE')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
            DropTable("dbo.Teams");
            DropTable("dbo.Status");
            DropTable("dbo.Projects");
            DropTable("dbo.Organizations");
            DropTable("dbo.Comments");
        }
    }
}
