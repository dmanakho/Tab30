namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsReturnedAddedToRepairModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Repairs", "IsUnitReturned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Repairs", "IsUnitReturned");
        }
    }
}
