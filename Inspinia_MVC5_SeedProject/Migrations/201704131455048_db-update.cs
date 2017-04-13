namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenCompras", "incluyeIgv", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrdenCompras", "monedaId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenCompras", "monedaId");
            AddForeignKey("dbo.OrdenCompras", "monedaId", "dbo.Monedas", "monedaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompras", "monedaId", "dbo.Monedas");
            DropIndex("dbo.OrdenCompras", new[] { "monedaId" });
            DropColumn("dbo.OrdenCompras", "monedaId");
            DropColumn("dbo.OrdenCompras", "incluyeIgv");
        }
    }
}
