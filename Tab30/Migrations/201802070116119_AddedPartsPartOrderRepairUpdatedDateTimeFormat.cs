namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPartsPartOrderRepairUpdatedDateTimeFormat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderedOn = c.DateTime(nullable: false),
                        ReceivedOn = c.DateTime(nullable: false),
                        RepaidID = c.Int(nullable: false),
                        PartID = c.Int(nullable: false),
                        Repair_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parts", t => t.PartID, cascadeDelete: true)
                .ForeignKey("dbo.Repairs", t => t.Repair_ID)
                .Index(t => t.PartID)
                .Index(t => t.Repair_ID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PartNo = c.String(),
                        Description = c.String(),
                        RefundRate = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Tablets", "TabletName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Repairs", "VendorCaseNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Repairs", "UpdatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Repairs", "IsBoxRequested", c => c.Boolean(nullable: false));
            AddColumn("dbo.Repairs", "BoxRequestedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Repairs", "IsShipped", c => c.Boolean(nullable: false));
            AddColumn("dbo.Repairs", "ShippedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Repairs", "ReturnedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Repairs", "RepairClosed", c => c.DateTime());
            DropColumn("dbo.Tablets", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tablets", "Name", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.PartOrders", "Repair_ID", "dbo.Repairs");
            DropForeignKey("dbo.PartOrders", "PartID", "dbo.Parts");
            DropIndex("dbo.PartOrders", new[] { "Repair_ID" });
            DropIndex("dbo.PartOrders", new[] { "PartID" });
            AlterColumn("dbo.Repairs", "RepairClosed", c => c.DateTime(nullable: false));
            DropColumn("dbo.Repairs", "ReturnedOn");
            DropColumn("dbo.Repairs", "ShippedOn");
            DropColumn("dbo.Repairs", "IsShipped");
            DropColumn("dbo.Repairs", "BoxRequestedOn");
            DropColumn("dbo.Repairs", "IsBoxRequested");
            DropColumn("dbo.Repairs", "UpdatedOn");
            DropColumn("dbo.Repairs", "VendorCaseNo");
            DropColumn("dbo.Tablets", "TabletName");
            DropTable("dbo.Parts");
            DropTable("dbo.PartOrders");
        }
    }
}
