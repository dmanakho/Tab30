namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimeFieldsNullableinPartORderTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PartOrders", "ReceivedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartOrders", "ReceivedOn", c => c.DateTime(nullable: false));
        }
    }
}
