namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdenCompraViewModels",
                c => new
                    {
                        ordenCompraViewModelId = c.Int(nullable: false, identity: true),
                        Requerimiento_requerimientoId = c.Int(),
                        TipoCompra_tipoCompraId = c.Int(),
                    })
                .PrimaryKey(t => t.ordenCompraViewModelId)
                .ForeignKey("dbo.Requerimientoes", t => t.Requerimiento_requerimientoId)
                .ForeignKey("dbo.TipoCompras", t => t.TipoCompra_tipoCompraId)
                .Index(t => t.Requerimiento_requerimientoId)
                .Index(t => t.TipoCompra_tipoCompraId);
            
            AddColumn("dbo.Monedas", "OrdenCompraViewModel_ordenCompraViewModelId", c => c.Int());
            AddColumn("dbo.OrdenCompras", "OrdenCompraViewModel_ordenCompraViewModelId", c => c.Int());
            AddColumn("dbo.FormaPagoes", "OrdenCompraViewModel_ordenCompraViewModelId", c => c.Int());
            AddColumn("dbo.Proveedors", "OrdenCompraViewModel_ordenCompraViewModelId", c => c.Int());
            CreateIndex("dbo.Monedas", "OrdenCompraViewModel_ordenCompraViewModelId");
            CreateIndex("dbo.OrdenCompras", "OrdenCompraViewModel_ordenCompraViewModelId");
            CreateIndex("dbo.FormaPagoes", "OrdenCompraViewModel_ordenCompraViewModelId");
            CreateIndex("dbo.Proveedors", "OrdenCompraViewModel_ordenCompraViewModelId");
            AddForeignKey("dbo.FormaPagoes", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels", "ordenCompraViewModelId");
            AddForeignKey("dbo.Monedas", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels", "ordenCompraViewModelId");
            AddForeignKey("dbo.OrdenCompras", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels", "ordenCompraViewModelId");
            AddForeignKey("dbo.Proveedors", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels", "ordenCompraViewModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenCompraViewModels", "TipoCompra_tipoCompraId", "dbo.TipoCompras");
            DropForeignKey("dbo.OrdenCompraViewModels", "Requerimiento_requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.Proveedors", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels");
            DropForeignKey("dbo.OrdenCompras", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels");
            DropForeignKey("dbo.Monedas", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels");
            DropForeignKey("dbo.FormaPagoes", "OrdenCompraViewModel_ordenCompraViewModelId", "dbo.OrdenCompraViewModels");
            DropIndex("dbo.OrdenCompraViewModels", new[] { "TipoCompra_tipoCompraId" });
            DropIndex("dbo.OrdenCompraViewModels", new[] { "Requerimiento_requerimientoId" });
            DropIndex("dbo.Proveedors", new[] { "OrdenCompraViewModel_ordenCompraViewModelId" });
            DropIndex("dbo.FormaPagoes", new[] { "OrdenCompraViewModel_ordenCompraViewModelId" });
            DropIndex("dbo.OrdenCompras", new[] { "OrdenCompraViewModel_ordenCompraViewModelId" });
            DropIndex("dbo.Monedas", new[] { "OrdenCompraViewModel_ordenCompraViewModelId" });
            DropColumn("dbo.Proveedors", "OrdenCompraViewModel_ordenCompraViewModelId");
            DropColumn("dbo.FormaPagoes", "OrdenCompraViewModel_ordenCompraViewModelId");
            DropColumn("dbo.OrdenCompras", "OrdenCompraViewModel_ordenCompraViewModelId");
            DropColumn("dbo.Monedas", "OrdenCompraViewModel_ordenCompraViewModelId");
            DropTable("dbo.OrdenCompraViewModels");
        }
    }
}
