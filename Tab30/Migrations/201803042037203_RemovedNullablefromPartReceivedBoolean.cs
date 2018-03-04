namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNullablefromPartReceivedBoolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PartOrders", "IsPartReceived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartOrders", "IsPartReceived", c => c.Boolean());
        }
    }
}
