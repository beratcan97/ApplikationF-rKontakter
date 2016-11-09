namespace ApplikationFörKontakter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.people",
                c => new
                    {
                        nyckel = c.Int(nullable: false, identity: true),
                        namn = c.String(),
                        gatuadress = c.String(),
                        postnummer = c.Int(nullable: false),
                        postort = c.String(),
                        telefon = c.String(),
                        epost = c.String(),
                        födelsedag = c.String(),
                    })
                .PrimaryKey(t => t.nyckel);
            
            DropTable("dbo.Blogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            DropTable("dbo.people");
        }
    }
}
