namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredImportIDfield : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "ImportID" });
            AlterColumn("dbo.Users", "ImportID", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Users", "ImportID", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "ImportID" });
            AlterColumn("dbo.Users", "ImportID", c => c.String(maxLength: 50));
            CreateIndex("dbo.Users", "ImportID", unique: true);
        }
    }
}
