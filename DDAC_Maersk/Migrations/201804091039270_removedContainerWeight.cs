namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedContainerWeight : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Containers", "WeightofContainer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Containers", "WeightofContainer", c => c.String(nullable: false));
        }
    }
}
