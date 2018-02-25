namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasedTabletNameLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tablets", "TabletName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tablets", "TabletName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
