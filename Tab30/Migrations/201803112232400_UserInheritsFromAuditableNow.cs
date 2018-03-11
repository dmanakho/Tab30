namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInheritsFromAuditableNow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Users", "UpdatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Users", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "RowVersion");
            DropColumn("dbo.Users", "UpdatedBy");
            DropColumn("dbo.Users", "CreatedBy");
        }
    }
}
