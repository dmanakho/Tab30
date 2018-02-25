namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadePartsFieldsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parts", "PartNo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Parts", "Description", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parts", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Parts", "PartNo", c => c.String(maxLength: 50));
        }
    }
}
