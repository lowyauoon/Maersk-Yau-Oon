namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipId = c.Int(nullable: false, identity: true),
                        ShipName = c.String(),
                        ShipContainerNumber = c.String(),
                    })
                .PrimaryKey(t => t.ShipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ships");
        }
    }
}
