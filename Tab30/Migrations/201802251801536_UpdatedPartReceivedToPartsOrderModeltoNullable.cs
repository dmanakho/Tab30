namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPartReceivedToPartsOrderModeltoNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PartOrders", "IsPartReceived", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartOrders", "IsPartReceived", c => c.Boolean(nullable: false));
        }
    }
}
