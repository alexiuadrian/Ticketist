namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusSuspended : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status (Name) VALUES ('SUSPENDED')");
        }
        
        public override void Down()
        {
        }
    }
}
