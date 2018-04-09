namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0f6f1962-ad12-4c57-8fb1-6cdcbeba8dfb', N'admin@ml.com', 0, N'AFruzfM+mk4oSf3mGIDAPlk0bca2oRRmYx1+T5Zxqnm7EkpQxbJvhfrSYBRrCcQ8eA==', N'fcb41e15-0e0a-4880-9f78-425defabbe2c', NULL, 0, 0, NULL, 1, 0, N'admin@ml.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9c14806a-54f8-40a5-8d37-558b11abc847', N'guest@vidly.com', 0, N'AIbmD46PyLtc357cDaTYHOjCgwOVrBr50CKboQ14wZ0HD3wtYJ/qTWJx3geZU5eXnw==', N'51362842-f151-4364-b742-5df88cd7b8cc', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b12b1fdc-9354-4619-ab81-30f90f69f3ae', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0f6f1962-ad12-4c57-8fb1-6cdcbeba8dfb', N'b12b1fdc-9354-4619-ab81-30f90f69f3ae')
");

        }
        
        public override void Down()
        {
        }
    }
}
