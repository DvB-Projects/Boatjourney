namespace BoatJourney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(nullable: false),
                        HouseNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Person", "AddressId", c => c.Int());
            CreateIndex("dbo.Person", "AddressId");
            AddForeignKey("dbo.Person", "AddressId", "dbo.Address", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "AddressId", "dbo.Address");
            DropIndex("dbo.Person", new[] { "AddressId" });
            DropColumn("dbo.Person", "AddressId");
            DropTable("dbo.Address");
        }
    }
}
