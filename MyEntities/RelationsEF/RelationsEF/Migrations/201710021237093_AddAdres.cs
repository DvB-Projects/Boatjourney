namespace RelationsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nummer = c.Int(nullable: false),
                        Straat = c.String(),
                        Bus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Persoon", "AdresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Persoon", "AdresId");
            AddForeignKey("dbo.Persoon", "AdresId", "dbo.Adres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persoon", "AdresId", "dbo.Adres");
            DropIndex("dbo.Persoon", new[] { "AdresId" });
            DropColumn("dbo.Persoon", "AdresId");
            DropTable("dbo.Adres");
        }
    }
}
