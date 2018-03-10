namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedTechNavigationalPropertyyinRepairModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Repairs", "TechID", "dbo.Teches");
            DropIndex("dbo.Repairs", new[] { "TechID" });
            DropColumn("dbo.Repairs", "TechID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Repairs", "TechID", c => c.Int(nullable: false));
            CreateIndex("dbo.Repairs", "TechID");
            AddForeignKey("dbo.Repairs", "TechID", "dbo.Teches", "ID");
        }
    }
}
