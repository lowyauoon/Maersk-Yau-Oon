namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderNotifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Schedules", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Ships", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Schedule_ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Orders", "Ship_ShipId", "dbo.Ships");
            DropIndex("dbo.Orders", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.Orders", new[] { "Ship_ShipId" });
            DropIndex("dbo.Customers", new[] { "Order_OrderID" });
            DropIndex("dbo.Schedules", new[] { "Order_OrderID" });
            DropIndex("dbo.Ships", new[] { "Order_OrderID" });
            RenameColumn(table: "dbo.Orders", name: "Schedule_ScheduleID", newName: "ScheduleID");
            RenameColumn(table: "dbo.Orders", name: "Ship_ShipId", newName: "ShipId");
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ScheduleID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ShipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerID");
            CreateIndex("dbo.Orders", "ShipId");
            CreateIndex("dbo.Orders", "ScheduleID");
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ScheduleID", "dbo.Schedules", "ScheduleID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ShipId", "dbo.Ships", "ShipId", cascadeDelete: true);
            DropColumn("dbo.Customers", "Order_OrderID");
            DropColumn("dbo.Schedules", "Order_OrderID");
            DropColumn("dbo.Ships", "Order_OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ships", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Schedules", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Customers", "Order_OrderID", c => c.Int());
            DropForeignKey("dbo.Orders", "ShipId", "dbo.Ships");
            DropForeignKey("dbo.Orders", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "ScheduleID" });
            DropIndex("dbo.Orders", new[] { "ShipId" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            AlterColumn("dbo.Orders", "ShipId", c => c.Int());
            AlterColumn("dbo.Orders", "ScheduleID", c => c.Int());
            DropColumn("dbo.Orders", "CustomerID");
            RenameColumn(table: "dbo.Orders", name: "ShipId", newName: "Ship_ShipId");
            RenameColumn(table: "dbo.Orders", name: "ScheduleID", newName: "Schedule_ScheduleID");
            CreateIndex("dbo.Ships", "Order_OrderID");
            CreateIndex("dbo.Schedules", "Order_OrderID");
            CreateIndex("dbo.Customers", "Order_OrderID");
            CreateIndex("dbo.Orders", "Ship_ShipId");
            CreateIndex("dbo.Orders", "Schedule_ScheduleID");
            AddForeignKey("dbo.Orders", "Ship_ShipId", "dbo.Ships", "ShipId");
            AddForeignKey("dbo.Orders", "Schedule_ScheduleID", "dbo.Schedules", "ScheduleID");
            AddForeignKey("dbo.Ships", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Schedules", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Customers", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
