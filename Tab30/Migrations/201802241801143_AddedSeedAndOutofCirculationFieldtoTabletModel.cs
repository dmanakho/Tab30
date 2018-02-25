namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeedAndOutofCirculationFieldtoTabletModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tablets", "OutOfCirculation", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tablets", "OutOfCirculation");
        }
    }
}
