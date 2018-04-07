namespace Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModelMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingAgent = c.String(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        ShipID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: true)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ShipID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        Origin = c.String(nullable: false),
                        Destination = c.String(nullable: false),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArrivalDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipContainerSpace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerType = c.String(nullable: false),
                        ContainerWeight = c.Double(nullable: false),
                        BookingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Containers", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Bookings", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Bookings", "CustomerID", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Containers", new[] { "BookingID" });
            DropIndex("dbo.Bookings", new[] { "ScheduleID" });
            DropIndex("dbo.Bookings", new[] { "ShipID" });
            DropIndex("dbo.Bookings", new[] { "CustomerID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Containers");
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
