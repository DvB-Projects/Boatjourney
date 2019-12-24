namespace BoatJourney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZipcode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zipcode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostCode = c.String(nullable: false),
                        PlaceOfStay = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Address", "ZipCodeId", c => c.Int());
            CreateIndex("dbo.Address", "ZipCodeId");
            AddForeignKey("dbo.Address", "ZipCodeId", "dbo.Zipcode", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "ZipCodeId", "dbo.Zipcode");
            DropIndex("dbo.Address", new[] { "ZipCodeId" });
            DropColumn("dbo.Address", "ZipCodeId");
            DropTable("dbo.Zipcode");
        }
    }
}
