namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderAgent = c.String(nullable: false),
                        Schedule_ScheduleID = c.Int(),
                        Ship_ShipId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleID)
                .ForeignKey("dbo.Ships", t => t.Ship_ShipId)
                .Index(t => t.Schedule_ScheduleID)
                .Index(t => t.Ship_ShipId);
            
            AddColumn("dbo.Containers", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Schedules", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Ships", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.Containers", "OrderID");
            CreateIndex("dbo.Customers", "Order_OrderID");
            CreateIndex("dbo.Schedules", "Order_OrderID");
            CreateIndex("dbo.Ships", "Order_OrderID");
            AddForeignKey("dbo.Customers", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Schedules", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Ships", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Containers", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Ships", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Ship_ShipId", "dbo.Ships");
            DropForeignKey("dbo.Schedules", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Customers", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Ships", new[] { "Order_OrderID" });
            DropIndex("dbo.Schedules", new[] { "Order_OrderID" });
            DropIndex("dbo.Customers", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "Ship_ShipId" });
            DropIndex("dbo.Orders", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.Containers", new[] { "OrderID" });
            DropColumn("dbo.Ships", "Order_OrderID");
            DropColumn("dbo.Schedules", "Order_OrderID");
            DropColumn("dbo.Customers", "Order_OrderID");
            DropColumn("dbo.Containers", "OrderID");
            DropTable("dbo.Orders");
        }
    }
}
