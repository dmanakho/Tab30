namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeOutOfCirculationReasonNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tablets", "OutOfCirculationReason", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tablets", "OutOfCirculationReason", c => c.Int(nullable: false));
        }
    }
}
