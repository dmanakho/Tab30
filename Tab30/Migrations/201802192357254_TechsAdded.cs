namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TechsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Repairs", "TechID", c => c.Int(nullable: false));
            CreateIndex("dbo.Repairs", "TechID");
            AddForeignKey("dbo.Repairs", "TechID", "dbo.Teches", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "TechID", "dbo.Teches");
            DropIndex("dbo.Repairs", new[] { "TechID" });
            DropColumn("dbo.Repairs", "TechID");
            DropTable("dbo.Teches");
        }
    }
}
