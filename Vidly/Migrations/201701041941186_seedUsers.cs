namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'540d429b-79d1-4c05-aa64-3ab911d99dd0', N'admin@vidly.com', 0, N'ALQGgooSdb4BxJVHhRctd6w3XBl+/I+0R5fFzk6mGuCjpJY4gaZC+9A9ZBnkqO0+iA==', N'ed9d3714-2ba4-4d67-9338-91d1c65f7f6d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'77b6b4b5-b017-4dd4-85ff-fa0cab2f30b3', N'guest@vidly.com', 0, N'APmKoJDlPWgbbtl1pFq2c22ZH3S/S+mCru+fnhhJd0m6r3OBiXBLV3JlN+0waDamJw==', N'febab187-c383-4cce-8e11-124a5d3e7348', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2bfc791c-83eb-4829-a94f-ee7e26262b8a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'540d429b-79d1-4c05-aa64-3ab911d99dd0', N'2bfc791c-83eb-4829-a94f-ee7e26262b8a')
");
        }
        
        public override void Down()
        {
        }
    }
}
