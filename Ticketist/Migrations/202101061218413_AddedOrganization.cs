namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrganization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Code = c.String(maxLength: 3),
                        Description = c.String(),
                        FoundationYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Organizations");
        }
    }
}
