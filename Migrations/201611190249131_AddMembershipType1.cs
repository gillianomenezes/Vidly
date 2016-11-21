namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE MembershipTypes SET Name='Pay as you go' WHERE DurationInMonths='0'");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE DurationInMonths='1'");
            Sql("UPDATE MembershipTypes SET Name='Quarthly' WHERE DurationInMonths='4'");
            Sql("UPDATE MembershipTypes SET Name='Yearly' WHERE DurationInMonths='12'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}