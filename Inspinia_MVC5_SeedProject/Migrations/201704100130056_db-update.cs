namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proveedors", "tipoMaterialId", "dbo.TipoMaterials");
            DropForeignKey("dbo.Proveedors", "formaPagoId", "dbo.FormaPagoes");
            DropIndex("dbo.Proveedors", new[] { "formaPagoId" });
            DropIndex("dbo.Proveedors", new[] { "tipoMaterialId" });
            AlterColumn("dbo.Proveedors", "direccion", c => c.String(maxLength: 500));
            AlterColumn("dbo.Proveedors", "representanteVentas", c => c.String(maxLength: 200));
            DropColumn("dbo.Proveedors", "formaPagoId");
            DropColumn("dbo.Proveedors", "tipoMaterialId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proveedors", "tipoMaterialId", c => c.Int(nullable: false));
            AddColumn("dbo.Proveedors", "formaPagoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Proveedors", "representanteVentas", c => c.String(maxLength: 100));
            AlterColumn("dbo.Proveedors", "direccion", c => c.String(maxLength: 200));
            CreateIndex("dbo.Proveedors", "tipoMaterialId");
            CreateIndex("dbo.Proveedors", "formaPagoId");
            AddForeignKey("dbo.Proveedors", "formaPagoId", "dbo.FormaPagoes", "formaPagoId");
            AddForeignKey("dbo.Proveedors", "tipoMaterialId", "dbo.TipoMaterials", "tipoMaterialId");
        }
    }
}
