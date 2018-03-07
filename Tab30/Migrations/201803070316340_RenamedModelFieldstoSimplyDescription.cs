namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedModelFieldstoSimplyDescription : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Repairs", "RepairDescription", "Description");
            RenameColumn("dbo.ProblemAreas", "ProblemDescription", "Description");
            RenameColumn("dbo.RepairTypes", "RepairTypeDescription", "Description");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Repairs", "Description", "RepairDescription");
            RenameColumn("dbo.ProblemAreas", "Description", "ProblemDescription");
            RenameColumn("dbo.RepairTypes", "Description", "RepairTypeDescription");
        }
    }
}
