namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketsAndStatuses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Summary = c.String(maxLength: 3000),
                        CreationDate = c.DateTime(nullable: false),
                        ReporterId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
            DropTable("dbo.Status");
        }
    }
}
