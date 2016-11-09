namespace ApplikationFörKontakter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.people", "postnummer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.people", "postnummer", c => c.Int(nullable: false));
        }
    }
}
