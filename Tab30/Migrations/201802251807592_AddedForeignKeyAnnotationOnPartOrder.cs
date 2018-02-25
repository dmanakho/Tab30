namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyAnnotationOnPartOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartOrders", "Repair_ID", "dbo.Repairs");
            DropIndex("dbo.PartOrders", new[] { "Repair_ID" });
            DropColumn("dbo.PartOrders", "RepaidID");
            RenameColumn(table: "dbo.PartOrders", name: "Repair_ID", newName: "RepaidID");
            AlterColumn("dbo.PartOrders", "RepaidID", c => c.Int(nullable: false));
            CreateIndex("dbo.PartOrders", "RepaidID");
            AddForeignKey("dbo.PartOrders", "RepaidID", "dbo.Repairs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartOrders", "RepaidID", "dbo.Repairs");
            DropIndex("dbo.PartOrders", new[] { "RepaidID" });
            AlterColumn("dbo.PartOrders", "RepaidID", c => c.Int());
            RenameColumn(table: "dbo.PartOrders", name: "RepaidID", newName: "Repair_ID");
            AddColumn("dbo.PartOrders", "RepaidID", c => c.Int(nullable: false));
            CreateIndex("dbo.PartOrders", "Repair_ID");
            AddForeignKey("dbo.PartOrders", "Repair_ID", "dbo.Repairs", "ID");
        }
    }
}
