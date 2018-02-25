namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportIDAddedforUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImportID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ImportID");
        }
    }
}
