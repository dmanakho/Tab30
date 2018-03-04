namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorCaseNumberisRequiredFieldNow : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Repairs", new[] { "VendorCaseNo" });
            AlterColumn("dbo.Repairs", "VendorCaseNo", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Repairs", "VendorCaseNo", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Repairs", new[] { "VendorCaseNo" });
            AlterColumn("dbo.Repairs", "VendorCaseNo", c => c.String(maxLength: 50));
            CreateIndex("dbo.Repairs", "VendorCaseNo", unique: true);
        }
    }
}
