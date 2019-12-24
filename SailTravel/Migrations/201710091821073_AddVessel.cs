namespace BoatJourney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVessel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vessel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfVessel = c.String(nullable: false),
                        NameOfVessel = c.String(nullable: false),
                        PassangerCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vessel");
        }
    }
}
