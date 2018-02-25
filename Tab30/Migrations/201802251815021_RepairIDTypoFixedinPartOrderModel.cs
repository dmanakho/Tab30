namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairIDTypoFixedinPartOrderModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PartOrders", name: "RepaidID", newName: "RepairID");
            RenameIndex(table: "dbo.PartOrders", name: "IX_RepaidID", newName: "IX_RepairID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PartOrders", name: "IX_RepairID", newName: "IX_RepaidID");
            RenameColumn(table: "dbo.PartOrders", name: "RepairID", newName: "RepaidID");
        }
    }
}
