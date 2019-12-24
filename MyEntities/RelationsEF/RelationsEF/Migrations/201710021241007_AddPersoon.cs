namespace RelationsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersoon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Persoon", "AdresId", "dbo.Adres");
            DropIndex("dbo.Persoon", new[] { "AdresId" });
            AlterColumn("dbo.Persoon", "AdresId", c => c.Int());
            CreateIndex("dbo.Persoon", "AdresId");
            AddForeignKey("dbo.Persoon", "AdresId", "dbo.Adres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persoon", "AdresId", "dbo.Adres");
            DropIndex("dbo.Persoon", new[] { "AdresId" });
            AlterColumn("dbo.Persoon", "AdresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Persoon", "AdresId");
            AddForeignKey("dbo.Persoon", "AdresId", "dbo.Adres", "Id", cascadeDelete: true);
        }
    }
}
