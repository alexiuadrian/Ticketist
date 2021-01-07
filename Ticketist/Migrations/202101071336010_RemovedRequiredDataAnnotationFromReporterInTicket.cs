namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredDataAnnotationFromReporterInTicket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Reporter", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Reporter", c => c.String(nullable: false));
        }
    }
}
