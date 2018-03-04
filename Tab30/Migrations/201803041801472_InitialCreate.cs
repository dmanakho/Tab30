namespace Tab30.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                .PrimaryKey(t => t.ID)
                .Index(t => t.ShortDescription, unique: true);
            
            CreateTable(
                "dbo.Tablets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TabletName = c.String(nullable: false, maxLength: 50),
                        Make = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 20),
                        AssetTag = c.String(maxLength: 20),
                        WarrantyExpiresOn = c.DateTime(),
                        ADPEnabled = c.Boolean(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        OutOfCirculation = c.Boolean(),
                        LocationID = c.Int(),
                        UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.TabletName, unique: true)
                .Index(t => t.SerialNo, unique: true)
                .Index(t => t.AssetTag, unique: true)
                .Index(t => t.LocationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorCaseNo = c.String(maxLength: 50),
                        RepairDescription = c.String(nullable: false, maxLength: 250),
                        IsComplete = c.Boolean(nullable: false),
                        RepairCreated = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        RepairClosed = c.DateTime(),
                        IsBoxRequested = c.Boolean(nullable: false),
                        BoxRequestedOn = c.DateTime(),
                        IsShipped = c.Boolean(nullable: false),
                        ShippedOn = c.DateTime(),
                        IsUnitReturned = c.Boolean(nullable: false),
                        ReturnedOn = c.DateTime(),
                        TabletID = c.Int(nullable: false),
                        RepairTypeID = c.Int(nullable: false),
                        TechID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RepairTypes", t => t.RepairTypeID)
                .ForeignKey("dbo.Tablets", t => t.TabletID)
                .ForeignKey("dbo.Teches", t => t.TechID)
                .Index(t => t.VendorCaseNo, unique: true)
                .Index(t => t.TabletID)
                .Index(t => t.RepairTypeID)
                .Index(t => t.TechID);
            
            CreateTable(
                "dbo.PartOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderedOn = c.DateTime(nullable: false),
                        IsPartReceived = c.Boolean(),
                        ReceivedOn = c.DateTime(nullable: false),
                        RepairID = c.Int(nullable: false),
                        PartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parts", t => t.PartID)
                .ForeignKey("dbo.Repairs", t => t.RepairID)
                .Index(t => t.RepairID)
                .Index(t => t.PartID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PartNo = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        RefundRate = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.PartNo, unique: true);
            
            CreateTable(
                "dbo.ProblemAreas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProblemDescription = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RepairTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RepairTypeDescription = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImportID = c.String(maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 20),
                        ClassOf = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ImportID, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.RepairProblemAreas",
                c => new
                    {
                        RepairID = c.Int(nullable: false),
                        ProblemAreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RepairID, t.ProblemAreaID })
                .ForeignKey("dbo.Repairs", t => t.RepairID)
                .ForeignKey("dbo.ProblemAreas", t => t.ProblemAreaID)
                .Index(t => t.RepairID)
                .Index(t => t.ProblemAreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tablets", "UserID", "dbo.Users");
            DropForeignKey("dbo.Repairs", "TechID", "dbo.Teches");
            DropForeignKey("dbo.Repairs", "TabletID", "dbo.Tablets");
            DropForeignKey("dbo.Repairs", "RepairTypeID", "dbo.RepairTypes");
            DropForeignKey("dbo.RepairProblemAreas", "ProblemAreaID", "dbo.ProblemAreas");
            DropForeignKey("dbo.RepairProblemAreas", "RepairID", "dbo.Repairs");
            DropForeignKey("dbo.PartOrders", "RepairID", "dbo.Repairs");
            DropForeignKey("dbo.PartOrders", "PartID", "dbo.Parts");
            DropForeignKey("dbo.Tablets", "LocationID", "dbo.Locations");
            DropIndex("dbo.RepairProblemAreas", new[] { "ProblemAreaID" });
            DropIndex("dbo.RepairProblemAreas", new[] { "RepairID" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "ImportID" });
            DropIndex("dbo.Teches", new[] { "UserName" });
            DropIndex("dbo.Parts", new[] { "PartNo" });
            DropIndex("dbo.PartOrders", new[] { "PartID" });
            DropIndex("dbo.PartOrders", new[] { "RepairID" });
            DropIndex("dbo.Repairs", new[] { "TechID" });
            DropIndex("dbo.Repairs", new[] { "RepairTypeID" });
            DropIndex("dbo.Repairs", new[] { "TabletID" });
            DropIndex("dbo.Repairs", new[] { "VendorCaseNo" });
            DropIndex("dbo.Tablets", new[] { "UserID" });
            DropIndex("dbo.Tablets", new[] { "LocationID" });
            DropIndex("dbo.Tablets", new[] { "AssetTag" });
            DropIndex("dbo.Tablets", new[] { "SerialNo" });
            DropIndex("dbo.Tablets", new[] { "TabletName" });
            DropIndex("dbo.Locations", new[] { "ShortDescription" });
            DropTable("dbo.RepairProblemAreas");
            DropTable("dbo.Users");
            DropTable("dbo.Teches");
            DropTable("dbo.RepairTypes");
            DropTable("dbo.ProblemAreas");
            DropTable("dbo.Parts");
            DropTable("dbo.PartOrders");
            DropTable("dbo.Repairs");
            DropTable("dbo.Tablets");
            DropTable("dbo.Locations");
        }
    }
}
