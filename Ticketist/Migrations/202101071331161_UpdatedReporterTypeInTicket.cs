namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedReporterTypeInTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Reporter", c => c.String(nullable: false));
            DropColumn("dbo.Tickets", "ReporterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ReporterId", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "Reporter");
        }
    }
}
