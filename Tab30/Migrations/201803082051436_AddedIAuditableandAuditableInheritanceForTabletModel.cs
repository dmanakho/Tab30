namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIAuditableandAuditableInheritanceForTabletModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tablets", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Tablets", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Tablets", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Tablets", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Tablets", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tablets", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tablets", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tablets", "RowVersion");
            DropColumn("dbo.Tablets", "UpdatedBy");
            DropColumn("dbo.Tablets", "CreatedBy");
        }
    }
}
