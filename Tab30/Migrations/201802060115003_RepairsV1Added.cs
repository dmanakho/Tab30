namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairsV1Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RepairType = c.Int(nullable: false),
                        RepairDescription = c.String(),
                        Comment = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        RepairCreated = c.DateTime(nullable: false),
                        RepairClosed = c.DateTime(nullable: false),
                        TabletID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tablets", t => t.TabletID, cascadeDelete: true)
                .Index(t => t.TabletID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Repairs", "TabletID", "dbo.Tablets");
            DropIndex("dbo.Repairs", new[] { "TabletID" });
            DropTable("dbo.Repairs");
        }
    }
}
