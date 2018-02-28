namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFullDescriptionproblemarea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProblemAreas", "FullDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProblemAreas", "FullDescription");
        }
    }
}
