namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InheritedRepairFromAutitableAddedExceptionErrorChecks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Repairs", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Repairs", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Repairs", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Repairs", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Repairs", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Repairs", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Repairs", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Repairs", "RowVersion");
            DropColumn("dbo.Repairs", "UpdatedBy");
            DropColumn("dbo.Repairs", "CreatedBy");
        }
    }
}
