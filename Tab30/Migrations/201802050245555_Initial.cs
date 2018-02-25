namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortDescription = c.String(nullable: false, maxLength: 5),
                        LongDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tablets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Make = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 20),
                        AssetTag = c.String(maxLength: 20),
                        WarrantyExpiresOn = c.DateTime(),
                        ADPEnabled = c.Boolean(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        LocationID = c.Int(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.LocationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 20),
                        ClassOf = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tablets", "UserID", "dbo.Users");
            DropForeignKey("dbo.Tablets", "LocationID", "dbo.Locations");
            DropIndex("dbo.Tablets", new[] { "UserID" });
            DropIndex("dbo.Tablets", new[] { "LocationID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tablets");
            DropTable("dbo.Locations");
        }
    }
}
