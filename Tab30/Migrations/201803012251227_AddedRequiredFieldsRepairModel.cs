namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredFieldsRepairModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Repairs", "RepairDescription", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Repairs", "RepairDescription", c => c.String(maxLength: 250));
        }
    }
}
