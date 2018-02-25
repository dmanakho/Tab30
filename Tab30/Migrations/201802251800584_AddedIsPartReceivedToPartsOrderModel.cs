namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsPartReceivedToPartsOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartOrders", "IsPartReceived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartOrders", "IsPartReceived");
        }
    }
}
