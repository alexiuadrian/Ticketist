namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Description", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Organizations", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Organizations", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teams", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Teams", "ProjectId", c => c.Int());
            AlterColumn("dbo.Tickets", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tickets", "Summary", c => c.String(nullable: false, maxLength: 3000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Summary", c => c.String(maxLength: 3000));
            AlterColumn("dbo.Tickets", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Teams", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teams", "Code", c => c.String(maxLength: 3));
            AlterColumn("dbo.Teams", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Organizations", "Description", c => c.String());
            AlterColumn("dbo.Organizations", "Code", c => c.String(maxLength: 3));
            AlterColumn("dbo.Organizations", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Comments", "Description", c => c.String(maxLength: 1000));
        }
    }
}
