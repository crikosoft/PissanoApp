namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Almacens",
                c => new
                    {
                        almacenId = c.Int(nullable: false, identity: true),
                        obraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.almacenId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .Index(t => t.obraId);
            
            CreateTable(
                "dbo.Obras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        direccion = c.String(nullable: false),
                        fechaInicio = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        tiempoEjecucion = c.Int(nullable: false),
                        empresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Empresas", t => t.empresaId)
                .Index(t => t.empresaId);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        empresaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        ruc = c.String(nullable: false),
                        agenteRetenedor = c.Boolean(nullable: false),
                        telefono = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.empresaId);
            
            CreateTable(
                "dbo.Presupuestoes",
                c => new
                    {
                        presupuestoId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false, maxLength: 200),
                        obraId = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        plazo = c.Int(nullable: false),
                        monedaId = c.Int(nullable: false),
                        total = c.Double(nullable: false),
                        tipoPresupuestoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.presupuestoId)
                .ForeignKey("dbo.Monedas", t => t.monedaId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .ForeignKey("dbo.TipoPresupuestoes", t => t.tipoPresupuestoId)
                .Index(t => t.obraId)
                .Index(t => t.monedaId)
                .Index(t => t.tipoPresupuestoId);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        monedaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.monedaId);
            
            CreateTable(
                "dbo.PresupuestoDetalles",
                c => new
                    {
                        presupuestoDetalleId = c.Int(nullable: false, identity: true),
                        presupuestoId = c.Int(nullable: false),
                        materialId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        precioUnitario = c.Double(nullable: false),
                        precioTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.presupuestoDetalleId)
                .ForeignKey("dbo.Materials", t => t.materialId)
                .ForeignKey("dbo.Presupuestoes", t => t.presupuestoId)
                .Index(t => t.presupuestoId)
                .Index(t => t.materialId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        materialId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 500),
                        codigo = c.String(nullable: false, maxLength: 20),
                        unidadMedidaId = c.Int(nullable: false),
                        tipoMaterialId = c.Int(nullable: false),
                        materialPadreId = c.Int(),
                    })
                .PrimaryKey(t => t.materialId)
                .ForeignKey("dbo.Materials", t => t.materialPadreId)
                .ForeignKey("dbo.TipoMaterials", t => t.tipoMaterialId)
                .ForeignKey("dbo.UnidadMedidas", t => t.unidadMedidaId)
                .Index(t => t.unidadMedidaId)
                .Index(t => t.tipoMaterialId)
                .Index(t => t.materialPadreId);
            
            CreateTable(
                "dbo.TipoMaterials",
                c => new
                    {
                        tipoMaterialId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.tipoMaterialId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        proveedorId = c.Int(nullable: false, identity: true),
                        razonSocial = c.String(nullable: false),
                        direccion = c.String(maxLength: 200),
                        representanteVentas = c.String(maxLength: 100),
                        email = c.String(),
                        telefono = c.String(),
                        movil = c.String(),
                        numeroCuenta = c.String(maxLength: 100),
                        formaPagoId = c.Int(nullable: false),
                        tipoMaterialId = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                        ruc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.proveedorId)
                .ForeignKey("dbo.TipoMaterials", t => t.tipoMaterialId)
                .ForeignKey("dbo.FormaPagoes", t => t.formaPagoId)
                .Index(t => t.formaPagoId)
                .Index(t => t.tipoMaterialId);
            
            CreateTable(
                "dbo.FormaPagoes",
                c => new
                    {
                        formaPagoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.formaPagoId);
            
            CreateTable(
                "dbo.OrdenCompras",
                c => new
                    {
                        ordenCompraId = c.Int(nullable: false, identity: true),
                        numero = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        proveedorId = c.Int(nullable: false),
                        igv = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        obraId = c.Int(nullable: false),
                        estadoOrdenId = c.Int(nullable: false),
                        requerimientoId = c.Int(nullable: false),
                        comentario = c.String(),
                        adelanto = c.Int(nullable: false),
                        formaPagoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ordenCompraId)
                .ForeignKey("dbo.EstadoOrdens", t => t.estadoOrdenId)
                .ForeignKey("dbo.FormaPagoes", t => t.formaPagoId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .ForeignKey("dbo.Proveedors", t => t.proveedorId)
                .ForeignKey("dbo.Requerimientoes", t => t.requerimientoId)
                .Index(t => t.proveedorId)
                .Index(t => t.obraId)
                .Index(t => t.estadoOrdenId)
                .Index(t => t.requerimientoId)
                .Index(t => t.formaPagoId);
            
            CreateTable(
                "dbo.EstadoOrdens",
                c => new
                    {
                        estadoOrdenId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.estadoOrdenId);
            
            CreateTable(
                "dbo.OrdenCompraDetalles",
                c => new
                    {
                        ordenCompradetalleId = c.Int(nullable: false, identity: true),
                        ordenCompraId = c.Int(nullable: false),
                        materialId = c.Int(nullable: false),
                        cantidad = c.Double(nullable: false),
                        precioUnitario = c.Double(nullable: false),
                        precioTotal = c.Double(nullable: false),
                        estadoOrdenDetalleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ordenCompradetalleId)
                .ForeignKey("dbo.EstadoOrdenDetalles", t => t.estadoOrdenDetalleId)
                .ForeignKey("dbo.Materials", t => t.materialId)
                .ForeignKey("dbo.OrdenCompras", t => t.ordenCompraId)
                .Index(t => t.ordenCompraId)
                .Index(t => t.materialId)
                .Index(t => t.estadoOrdenDetalleId);
            
            CreateTable(
                "dbo.EstadoOrdenDetalles",
                c => new
                    {
                        estadoOrdenDetalleId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.estadoOrdenDetalleId);
            
            CreateTable(
                "dbo.Requerimientoes",
                c => new
                    {
                        requerimientoId = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        obraId = c.Int(nullable: false),
                        numero = c.String(),
                    })
                .PrimaryKey(t => t.requerimientoId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .Index(t => t.obraId);
            
            CreateTable(
                "dbo.UnidadMedidas",
                c => new
                    {
                        unidadMedidaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        sigla = c.String(),
                    })
                .PrimaryKey(t => t.unidadMedidaId);
            
            CreateTable(
                "dbo.TipoPresupuestoes",
                c => new
                    {
                        tipoPresupuestoId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tipoPresupuestoId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        categoriaId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false, maxLength: 200),
                        codigo = c.String(nullable: false, maxLength: 10),
                        categoriaPadreId = c.Int(),
                    })
                .PrimaryKey(t => t.categoriaId)
                .ForeignKey("dbo.Categorias", t => t.categoriaPadreId)
                .Index(t => t.categoriaPadreId);
            
            CreateTable(
                "dbo.DocumentoPagoes",
                c => new
                    {
                        documentoPagoId = c.Int(nullable: false, identity: true),
                        numero = c.String(),
                        tipoDocumentoId = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.documentoPagoId)
                .ForeignKey("dbo.TipoDocumentoes", t => t.tipoDocumentoId)
                .Index(t => t.tipoDocumentoId);
            
            CreateTable(
                "dbo.TipoDocumentoes",
                c => new
                    {
                        tipoDocumentoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.tipoDocumentoId);
            
            CreateTable(
                "dbo.IngresoDetalles",
                c => new
                    {
                        ingresoDetalleId = c.Int(nullable: false, identity: true),
                        ordenCompradetalleId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        avance = c.Double(nullable: false),
                        Ingreso_ingresoId = c.Int(),
                    })
                .PrimaryKey(t => t.ingresoDetalleId)
                .ForeignKey("dbo.Ingresoes", t => t.Ingreso_ingresoId)
                .ForeignKey("dbo.OrdenCompraDetalles", t => t.ordenCompradetalleId)
                .Index(t => t.ordenCompradetalleId)
                .Index(t => t.Ingreso_ingresoId);
            
            CreateTable(
                "dbo.Ingresoes",
                c => new
                    {
                        ingresoId = c.Int(nullable: false, identity: true),
                        ordenCompraId = c.Int(nullable: false),
                        numeroGuia = c.String(),
                        fecha = c.DateTime(nullable: false),
                        DocumentoPago_documentoPagoId = c.Int(),
                    })
                .PrimaryKey(t => t.ingresoId)
                .ForeignKey("dbo.DocumentoPagoes", t => t.DocumentoPago_documentoPagoId)
                .ForeignKey("dbo.OrdenCompras", t => t.ordenCompraId)
                .Index(t => t.ordenCompraId)
                .Index(t => t.DocumentoPago_documentoPagoId);
            
            CreateTable(
                "dbo.MaterialNivelStocks",
                c => new
                    {
                        materialNivelStockId = c.Int(nullable: false, identity: true),
                        almacenId = c.Int(nullable: false),
                        materialId = c.Int(nullable: false),
                        fechaStock = c.DateTime(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.materialNivelStockId)
                .ForeignKey("dbo.Almacens", t => t.almacenId)
                .ForeignKey("dbo.Materials", t => t.materialId)
                .Index(t => t.almacenId)
                .Index(t => t.materialId);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        partidaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.partidaId);
            
            CreateTable(
                "dbo.Tituloes",
                c => new
                    {
                        tituloId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tituloId);
            
            CreateTable(
                "dbo.RequerimientoDetalles",
                c => new
                    {
                        requerimientoDetalleId = c.Int(nullable: false, identity: true),
                        requerimientoId = c.Int(nullable: false),
                        materialId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.requerimientoDetalleId)
                .ForeignKey("dbo.Materials", t => t.materialId)
                .ForeignKey("dbo.Requerimientoes", t => t.requerimientoId)
                .Index(t => t.requerimientoId)
                .Index(t => t.materialId);
            
            CreateTable(
                "dbo.TituloPartidas",
                c => new
                    {
                        Titulo_tituloId = c.Int(nullable: false),
                        Partida_partidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Titulo_tituloId, t.Partida_partidaId })
                .ForeignKey("dbo.Tituloes", t => t.Titulo_tituloId, cascadeDelete: true)
                .ForeignKey("dbo.Partidas", t => t.Partida_partidaId, cascadeDelete: true)
                .Index(t => t.Titulo_tituloId)
                .Index(t => t.Partida_partidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequerimientoDetalles", "requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.RequerimientoDetalles", "materialId", "dbo.Materials");
            DropForeignKey("dbo.TituloPartidas", "Partida_partidaId", "dbo.Partidas");
            DropForeignKey("dbo.TituloPartidas", "Titulo_tituloId", "dbo.Tituloes");
            DropForeignKey("dbo.MaterialNivelStocks", "materialId", "dbo.Materials");
            DropForeignKey("dbo.MaterialNivelStocks", "almacenId", "dbo.Almacens");
            DropForeignKey("dbo.IngresoDetalles", "ordenCompradetalleId", "dbo.OrdenCompraDetalles");
            DropForeignKey("dbo.Ingresoes", "ordenCompraId", "dbo.OrdenCompras");
            DropForeignKey("dbo.IngresoDetalles", "Ingreso_ingresoId", "dbo.Ingresoes");
            DropForeignKey("dbo.Ingresoes", "DocumentoPago_documentoPagoId", "dbo.DocumentoPagoes");
            DropForeignKey("dbo.DocumentoPagoes", "tipoDocumentoId", "dbo.TipoDocumentoes");
            DropForeignKey("dbo.Categorias", "categoriaPadreId", "dbo.Categorias");
            DropForeignKey("dbo.Almacens", "obraId", "dbo.Obras");
            DropForeignKey("dbo.Presupuestoes", "tipoPresupuestoId", "dbo.TipoPresupuestoes");
            DropForeignKey("dbo.PresupuestoDetalles", "presupuestoId", "dbo.Presupuestoes");
            DropForeignKey("dbo.PresupuestoDetalles", "materialId", "dbo.Materials");
            DropForeignKey("dbo.Materials", "unidadMedidaId", "dbo.UnidadMedidas");
            DropForeignKey("dbo.Proveedors", "formaPagoId", "dbo.FormaPagoes");
            DropForeignKey("dbo.OrdenCompras", "requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.Requerimientoes", "obraId", "dbo.Obras");
            DropForeignKey("dbo.OrdenCompras", "proveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenCompraDetalles", "ordenCompraId", "dbo.OrdenCompras");
            DropForeignKey("dbo.OrdenCompraDetalles", "materialId", "dbo.Materials");
            DropForeignKey("dbo.OrdenCompraDetalles", "estadoOrdenDetalleId", "dbo.EstadoOrdenDetalles");
            DropForeignKey("dbo.OrdenCompras", "obraId", "dbo.Obras");
            DropForeignKey("dbo.OrdenCompras", "formaPagoId", "dbo.FormaPagoes");
            DropForeignKey("dbo.OrdenCompras", "estadoOrdenId", "dbo.EstadoOrdens");
            DropForeignKey("dbo.Proveedors", "tipoMaterialId", "dbo.TipoMaterials");
            DropForeignKey("dbo.Materials", "tipoMaterialId", "dbo.TipoMaterials");
            DropForeignKey("dbo.Materials", "materialPadreId", "dbo.Materials");
            DropForeignKey("dbo.Presupuestoes", "obraId", "dbo.Obras");
            DropForeignKey("dbo.Presupuestoes", "monedaId", "dbo.Monedas");
            DropForeignKey("dbo.Obras", "empresaId", "dbo.Empresas");
            DropIndex("dbo.TituloPartidas", new[] { "Partida_partidaId" });
            DropIndex("dbo.TituloPartidas", new[] { "Titulo_tituloId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "materialId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "requerimientoId" });
            DropIndex("dbo.MaterialNivelStocks", new[] { "materialId" });
            DropIndex("dbo.MaterialNivelStocks", new[] { "almacenId" });
            DropIndex("dbo.Ingresoes", new[] { "DocumentoPago_documentoPagoId" });
            DropIndex("dbo.Ingresoes", new[] { "ordenCompraId" });
            DropIndex("dbo.IngresoDetalles", new[] { "Ingreso_ingresoId" });
            DropIndex("dbo.IngresoDetalles", new[] { "ordenCompradetalleId" });
            DropIndex("dbo.DocumentoPagoes", new[] { "tipoDocumentoId" });
            DropIndex("dbo.Categorias", new[] { "categoriaPadreId" });
            DropIndex("dbo.Requerimientoes", new[] { "obraId" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "estadoOrdenDetalleId" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "materialId" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "ordenCompraId" });
            DropIndex("dbo.OrdenCompras", new[] { "formaPagoId" });
            DropIndex("dbo.OrdenCompras", new[] { "requerimientoId" });
            DropIndex("dbo.OrdenCompras", new[] { "estadoOrdenId" });
            DropIndex("dbo.OrdenCompras", new[] { "obraId" });
            DropIndex("dbo.OrdenCompras", new[] { "proveedorId" });
            DropIndex("dbo.Proveedors", new[] { "tipoMaterialId" });
            DropIndex("dbo.Proveedors", new[] { "formaPagoId" });
            DropIndex("dbo.Materials", new[] { "materialPadreId" });
            DropIndex("dbo.Materials", new[] { "tipoMaterialId" });
            DropIndex("dbo.Materials", new[] { "unidadMedidaId" });
            DropIndex("dbo.PresupuestoDetalles", new[] { "materialId" });
            DropIndex("dbo.PresupuestoDetalles", new[] { "presupuestoId" });
            DropIndex("dbo.Presupuestoes", new[] { "tipoPresupuestoId" });
            DropIndex("dbo.Presupuestoes", new[] { "monedaId" });
            DropIndex("dbo.Presupuestoes", new[] { "obraId" });
            DropIndex("dbo.Obras", new[] { "empresaId" });
            DropIndex("dbo.Almacens", new[] { "obraId" });
            DropTable("dbo.TituloPartidas");
            DropTable("dbo.RequerimientoDetalles");
            DropTable("dbo.Tituloes");
            DropTable("dbo.Partidas");
            DropTable("dbo.MaterialNivelStocks");
            DropTable("dbo.Ingresoes");
            DropTable("dbo.IngresoDetalles");
            DropTable("dbo.TipoDocumentoes");
            DropTable("dbo.DocumentoPagoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.TipoPresupuestoes");
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.Requerimientoes");
            DropTable("dbo.EstadoOrdenDetalles");
            DropTable("dbo.OrdenCompraDetalles");
            DropTable("dbo.EstadoOrdens");
            DropTable("dbo.OrdenCompras");
            DropTable("dbo.FormaPagoes");
            DropTable("dbo.Proveedors");
            DropTable("dbo.TipoMaterials");
            DropTable("dbo.Materials");
            DropTable("dbo.PresupuestoDetalles");
            DropTable("dbo.Monedas");
            DropTable("dbo.Presupuestoes");
            DropTable("dbo.Empresas");
            DropTable("dbo.Obras");
            DropTable("dbo.Almacens");
        }
    }
}
