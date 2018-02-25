namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairModelNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Repairs", "BoxRequestedOn", c => c.DateTime());
            AlterColumn("dbo.Repairs", "ShippedOn", c => c.DateTime());
            AlterColumn("dbo.Repairs", "ReturnedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Repairs", "ReturnedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Repairs", "ShippedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Repairs", "BoxRequestedOn", c => c.DateTime(nullable: false));
        }
    }
}
