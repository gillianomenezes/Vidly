namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres (name) VALUES ('Action')");
            Sql("INSERT INTO genres (name) VALUES ('Family')");
            Sql("INSERT INTO genres (name) VALUES ('Comedy')");
            Sql("INSERT INTO genres (name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
