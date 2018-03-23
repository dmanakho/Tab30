namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOutOfCirculationReasonPropertyToTabletModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tablets", "OutOfCirculationReason", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tablets", "OutOfCirculationReason");
        }
    }
}
