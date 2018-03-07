namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDatTimeFieldsClosedOnStartedOnandIsClosedField : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Repairs", "IsComplete", "IsClosed");
            RenameColumn("dbo.Repairs", "RepairCreated", "CreatedOn");
            RenameColumn("dbo.Repairs", "RepairClosed", "ClosedOn");

        }
        
        public override void Down()
        {
            RenameColumn("dbo.Repairs", "IsClosed", "IsComplete");
            RenameColumn("dbo.Repairs", "CreatedOn", "RepairCreated");
            RenameColumn("dbo.Repairs", "ClosedOn", "RepairClosed");
        }
    }
}
