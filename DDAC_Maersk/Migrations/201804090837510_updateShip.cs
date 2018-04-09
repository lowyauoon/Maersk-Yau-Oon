namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateShip : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ships", "ShipName", c => c.String(nullable: false));
            AlterColumn("dbo.Ships", "ShipContainerNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ships", "ShipContainerNumber", c => c.String());
            AlterColumn("dbo.Ships", "ShipName", c => c.String());
        }
    }
}
