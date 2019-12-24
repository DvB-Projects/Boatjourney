namespace BoatJourney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTravelVesselRelatie : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Vessel", newName: "Vessels");
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeTravel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vessels", "TravelId", c => c.Int());
            AlterColumn("dbo.Vessels", "TypeOfVessel", c => c.String());
            AlterColumn("dbo.Vessels", "NameOfVessel", c => c.String());
            CreateIndex("dbo.Vessels", "TravelId");
            AddForeignKey("dbo.Vessels", "TravelId", "dbo.Travels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vessels", "TravelId", "dbo.Travels");
            DropIndex("dbo.Vessels", new[] { "TravelId" });
            AlterColumn("dbo.Vessels", "NameOfVessel", c => c.String(nullable: false));
            AlterColumn("dbo.Vessels", "TypeOfVessel", c => c.String(nullable: false));
            DropColumn("dbo.Vessels", "TravelId");
            DropTable("dbo.Travels");
            RenameTable(name: "dbo.Vessels", newName: "Vessel");
        }
    }
}
