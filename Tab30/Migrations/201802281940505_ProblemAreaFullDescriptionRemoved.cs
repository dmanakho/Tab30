namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProblemAreaFullDescriptionRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProblemAreas", "FullDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProblemAreas", "FullDescription", c => c.String());
        }
    }
}
