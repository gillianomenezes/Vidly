namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres (name) VALUES ('Comedy')");
            Sql("INSERT INTO genres (name) VALUES ('Action')");
            Sql("INSERT INTO genres (name) VALUES ('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
