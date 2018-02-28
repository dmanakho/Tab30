namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasedLengthProblemAreasTo75 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProblemAreas", "Description", c => c.String(nullable: false, maxLength: 75));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProblemAreas", "Description", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
