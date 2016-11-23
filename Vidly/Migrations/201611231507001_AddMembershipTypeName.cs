namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());

            Sql("UPDATE membershiptypes SET name='Pay as you go' WHERE DurationInMonths='0'");
            Sql("UPDATE membershiptypes SET name='Monthly' WHERE DurationInMonths='1'");
            Sql("UPDATE membershiptypes SET name='Quarterly' WHERE DurationInMonths='4'");
            Sql("UPDATE membershiptypes SET name='Yearly' WHERE DurationInMonths='12'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
