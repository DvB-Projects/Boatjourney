namespace BoatJourney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTravelAgencyTravelRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TravelOrganisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOrganiser = c.String(),
                        BookingDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Travels", "TravelOrganiserId", c => c.Int());
            CreateIndex("dbo.Travels", "TravelOrganiserId");
            AddForeignKey("dbo.Travels", "TravelOrganiserId", "dbo.TravelOrganisers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travels", "TravelOrganiserId", "dbo.TravelOrganisers");
            DropIndex("dbo.Travels", new[] { "TravelOrganiserId" });
            DropColumn("dbo.Travels", "TravelOrganiserId");
            DropTable("dbo.TravelOrganisers");
        }
    }
}
