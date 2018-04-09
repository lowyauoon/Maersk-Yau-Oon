namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIntContainerWeight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Containers", "WeightofContainer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Containers", "WeightofContainer");
        }
    }
}
