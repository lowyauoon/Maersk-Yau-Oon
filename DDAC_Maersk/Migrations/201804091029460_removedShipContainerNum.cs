namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedShipContainerNum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ships", "ShipContainerNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ships", "ShipContainerNumber", c => c.String(nullable: false));
        }
    }
}
