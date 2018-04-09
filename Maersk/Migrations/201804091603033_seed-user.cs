namespace Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeduser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd355d96e-5e0e-4148-82dd-feff01c5843d', N'admin@maersk.com', 0, N'AISpgbcu9TktOMU+6VTTp0kr5Pa4wapohvyQ+1NMkT5Cz+scDJL6DZS4p64ryhfq6w==', N'f1c6ceba-ca0b-48fe-999a-c10483767a8c', NULL, 0, 0, NULL, 1, 0, N'admin@maersk.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'af92642d-7f39-4daa-b58a-6c5a3b642e3d', N'Admin')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd355d96e-5e0e-4148-82dd-feff01c5843d', N'af92642d-7f39-4daa-b58a-6c5a3b642e3d')


");

        }
        
        public override void Down()
        {
        }
    }
}
