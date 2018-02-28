namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProblemAreaModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProblemAreas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RepairProblemAreas",
                c => new
                    {
                        RepairID = c.Int(nullable: false),
                        ProblemAreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RepairID, t.ProblemAreaID })
                .ForeignKey("dbo.Repairs", t => t.RepairID, cascadeDelete: true)
                .ForeignKey("dbo.ProblemAreas", t => t.ProblemAreaID, cascadeDelete: true)
                .Index(t => t.RepairID)
                .Index(t => t.ProblemAreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairProblemAreas", "ProblemAreaID", "dbo.ProblemAreas");
            DropForeignKey("dbo.RepairProblemAreas", "RepairID", "dbo.Repairs");
            DropIndex("dbo.RepairProblemAreas", new[] { "ProblemAreaID" });
            DropIndex("dbo.RepairProblemAreas", new[] { "RepairID" });
            DropTable("dbo.RepairProblemAreas");
            DropTable("dbo.ProblemAreas");
        }
    }
}
