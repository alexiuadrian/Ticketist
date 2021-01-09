namespace Ticketist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a10f660f-1e40-44ff-950c-8c92db7ef56a', N'guest@ticketist.com', 0, N'AMV4ODg3HCF/kx6aVRR+Uk7Xe8uUQPaPFE8E/ph+gYtW//yO3ExsqrpFzocOc3jpMg==', N'069ef560-8cdb-488d-b831-b9f7bbeeb1bf', NULL, 0, 0, NULL, 1, 0, N'guest@ticketist.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'efc48fad-cdb6-450f-af20-4119a5a1b032', N'admin@ticketist.com', 0, N'AD7gaP+hN7mAzvIJDNGnCX+CtkjwYXF8wGDx6DyC+OoKAqRCgkUZrqyYOYLSKNdQeg==', N'94cb9cb8-8483-4c7e-abde-716f5757dbd0', NULL, 0, 0, NULL, 1, 0, N'admin@ticketist.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'74461dcc-df20-4704-9709-4569c49fd24f', N'CanManageOrganizations')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'efc48fad-cdb6-450f-af20-4119a5a1b032', N'74461dcc-df20-4704-9709-4569c49fd24f')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
