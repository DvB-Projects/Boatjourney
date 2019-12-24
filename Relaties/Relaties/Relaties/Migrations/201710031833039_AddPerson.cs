namespace Relaties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPerson : DbMigration
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
                        BusNr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePerson = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IdAddress = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.IdAddress)
                .Index(t => t.IdAddress);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "IdAddress", "dbo.Address");
            DropIndex("dbo.Person", new[] { "IdAddress" });
            DropTable("dbo.Person");
            DropTable("dbo.Address");
        }
    }
}
