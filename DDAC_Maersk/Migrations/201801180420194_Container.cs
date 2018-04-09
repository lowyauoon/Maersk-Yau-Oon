namespace DDAC_Maersk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Container : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        TypeOfContainer = c.String(nullable: false),
                        WeightofContainer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Containers");
        }
    }
}
