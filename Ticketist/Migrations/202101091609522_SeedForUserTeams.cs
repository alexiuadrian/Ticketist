namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedForUserTeams : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserTeams (Id, UserId, TeamId) VALUES (1, '13144bdb-f8fd-4f74-bdef-6cdff968f5da', 2)");
            Sql("INSERT INTO UserTeams (Id, UserId, TeamId) VALUES (2, '49837c7b-bbc3-447d-a865-7df0ee0b9408', 2)");
            Sql("INSERT INTO UserTeams (Id, UserId, TeamId) VALUES (3, 'a10f660f-1e40-44ff-950c-8c92db7ef56a', 2)");
            Sql("INSERT INTO UserTeams (Id, UserId, TeamId) VALUES (4, 'efc48fad-cdb6-450f-af20-4119a5a1b032', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
