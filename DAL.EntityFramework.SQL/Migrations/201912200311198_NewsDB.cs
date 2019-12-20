namespace DAL.EntityFramework.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsEntry",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TimeAdded = c.DateTime(nullable: false),
                        Headline = c.String(),
                        HeadlineUrl = c.String(),
                        NewsSource = c.String(),
                        Article = c.String(),
                        Imagepath = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsEntry");
        }
    }
}
