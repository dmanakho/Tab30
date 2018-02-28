namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairTypesModeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RepairTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RepairTypeDescription = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Repairs", "RepairTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.ProblemAreas", "ProblemDescription", c => c.String(nullable: false, maxLength: 75));
            CreateIndex("dbo.Repairs", "RepairTypeID");
            AddForeignKey("dbo.Repairs", "RepairTypeID", "dbo.RepairTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.Repairs", "RepairType");
            DropColumn("dbo.ProblemAreas", "Description");
            DropColumn("dbo.ProblemAreas", "FullDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProblemAreas", "FullDescription", c => c.String());
            AddColumn("dbo.ProblemAreas", "Description", c => c.String(nullable: false, maxLength: 75));
            AddColumn("dbo.Repairs", "RepairType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Repairs", "RepairTypeID", "dbo.RepairTypes");
            DropIndex("dbo.Repairs", new[] { "RepairTypeID" });
            DropColumn("dbo.ProblemAreas", "ProblemDescription");
            DropColumn("dbo.Repairs", "RepairTypeID");
            DropTable("dbo.RepairTypes");
        }
    }
}
