namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIntShipContainerNum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ships", "ShipContainerNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ships", "ShipContainerNumber");
        }
    }
}
