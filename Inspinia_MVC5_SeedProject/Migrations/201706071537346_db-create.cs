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
                        nombre = c.String(),
                        direccion = c.String(nullable: false),
                        fechaInicio = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        tiempoEjecucion = c.Int(nullable: false),
                        identificador = c.String(),
                        empresaId = c.Int(nullable: false),
                        usuarioCreacion = c.String(),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
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
                        simbolo = c.String(),
                    })
                .PrimaryKey(t => t.monedaId);
            
            CreateTable(
                "dbo.OrdenCompras",
                c => new
                    {
                        ordenCompraId = c.Int(nullable: false, identity: true),
                        numero = c.String(nullable: false),
                        proveedorId = c.Int(nullable: false),
                        incluyeIgv = c.Boolean(nullable: false),
                        subTotal = c.Double(nullable: false),
                        igv = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        obraId = c.Int(nullable: false),
                        estadoOrdenId = c.Int(nullable: false),
                        requerimientoId = c.Int(nullable: false),
                        comentario = c.String(),
                        adelanto = c.Int(nullable: false),
                        formaPagoId = c.Int(nullable: false),
                        usuarioCreacion = c.String(nullable: false),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
                        monedaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ordenCompraId)
                .ForeignKey("dbo.EstadoOrdens", t => t.estadoOrdenId)
                .ForeignKey("dbo.FormaPagoes", t => t.formaPagoId)
                .ForeignKey("dbo.Monedas", t => t.monedaId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .ForeignKey("dbo.Proveedors", t => t.proveedorId)
                .ForeignKey("dbo.Requerimientoes", t => t.requerimientoId)
                .Index(t => t.proveedorId)
                .Index(t => t.obraId)
                .Index(t => t.estadoOrdenId)
                .Index(t => t.requerimientoId)
                .Index(t => t.formaPagoId)
                .Index(t => t.monedaId);
            
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
                "dbo.FormaPagoes",
                c => new
                    {
                        formaPagoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.formaPagoId);
            
            CreateTable(
                "dbo.OrdenCompraEstadoOrdens",
                c => new
                    {
                        ordenCompraEstadoOrdenId = c.Int(nullable: false, identity: true),
                        ordenCompraId = c.Int(nullable: false),
                        estadoOrdenId = c.Int(nullable: false),
                        comentario = c.String(),
                        usuarioCreacion = c.String(nullable: false),
                        fechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ordenCompraEstadoOrdenId)
                .ForeignKey("dbo.EstadoOrdens", t => t.estadoOrdenId)
                .ForeignKey("dbo.OrdenCompras", t => t.ordenCompraId)
                .Index(t => t.ordenCompraId)
                .Index(t => t.estadoOrdenId);
            
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
                "dbo.Materials",
                c => new
                    {
                        materialId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 500),
                        codigo = c.String(nullable: false, maxLength: 20),
                        unidadMedidaId = c.Int(nullable: false),
                        tipoMaterialId = c.Int(nullable: false),
                        materialPadreId = c.Int(),
                        usuarioCreacion = c.String(),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
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
                "dbo.UnidadMedidas",
                c => new
                    {
                        unidadMedidaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        sigla = c.String(),
                    })
                .PrimaryKey(t => t.unidadMedidaId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        proveedorId = c.Int(nullable: false, identity: true),
                        razonSocial = c.String(nullable: false),
                        direccion = c.String(maxLength: 500),
                        representanteVentas = c.String(maxLength: 200),
                        email = c.String(),
                        telefono = c.String(),
                        movil = c.String(),
                        numeroCuenta = c.String(maxLength: 100),
                        estado = c.Boolean(nullable: false),
                        ruc = c.String(nullable: false),
                        usuarioCreacion = c.String(),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.proveedorId);
            
            CreateTable(
                "dbo.Requerimientoes",
                c => new
                    {
                        requerimientoId = c.Int(nullable: false, identity: true),
                        numero = c.String(maxLength: 10),
                        comentario = c.String(maxLength: 1000),
                        obraId = c.Int(nullable: false),
                        prioridadId = c.Int(nullable: false),
                        tipoCompraId = c.Int(),
                        estadoRequerimientoId = c.Int(nullable: false),
                        usuarioCreacion = c.String(nullable: false),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.requerimientoId)
                .ForeignKey("dbo.EstadoRequerimientoes", t => t.estadoRequerimientoId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .ForeignKey("dbo.Prioridads", t => t.prioridadId)
                .ForeignKey("dbo.TipoCompras", t => t.tipoCompraId)
                .Index(t => t.obraId)
                .Index(t => t.prioridadId)
                .Index(t => t.tipoCompraId)
                .Index(t => t.estadoRequerimientoId);
            
            CreateTable(
                "dbo.RequerimientoDetalles",
                c => new
                    {
                        requerimientoDetalleId = c.Int(nullable: false, identity: true),
                        requerimientoId = c.Int(nullable: false),
                        materialId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        partidaId = c.Int(nullable: false),
                        estadoRequerimientoDetalleId = c.Int(nullable: false),
                        ordenCompraId = c.Int(),
                    })
                .PrimaryKey(t => t.requerimientoDetalleId)
                .ForeignKey("dbo.EstadoRequerimientoDetalles", t => t.estadoRequerimientoDetalleId)
                .ForeignKey("dbo.Materials", t => t.materialId)
                .ForeignKey("dbo.OrdenCompras", t => t.ordenCompraId)
                .ForeignKey("dbo.Partidas", t => t.partidaId)
                .ForeignKey("dbo.Requerimientoes", t => t.requerimientoId)
                .Index(t => t.requerimientoId)
                .Index(t => t.materialId)
                .Index(t => t.partidaId)
                .Index(t => t.estadoRequerimientoDetalleId)
                .Index(t => t.ordenCompraId);
            
            CreateTable(
                "dbo.EstadoRequerimientoDetalles",
                c => new
                    {
                        estadoRequerimientoDetalleId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.estadoRequerimientoDetalleId);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        partidaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                        subPresupuestoId = c.Int(nullable: false),
                        usuarioCreacion = c.String(),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
                        Titulo_tituloId = c.Int(),
                    })
                .PrimaryKey(t => t.partidaId)
                .ForeignKey("dbo.SubPresupuestoes", t => t.subPresupuestoId)
                .ForeignKey("dbo.Tituloes", t => t.Titulo_tituloId)
                .Index(t => t.subPresupuestoId)
                .Index(t => t.Titulo_tituloId);
            
            CreateTable(
                "dbo.SubPresupuestoes",
                c => new
                    {
                        subPresupuestoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.subPresupuestoId);
            
            CreateTable(
                "dbo.RequerimientoDetalleEstadoRequerimientoDetalles",
                c => new
                    {
                        requerimientoDetalleEstadoRequerimientoDetalleId = c.Int(nullable: false, identity: true),
                        requerimientoDetalleId = c.Int(nullable: false),
                        estadoRequerimientoDetalleId = c.Int(nullable: false),
                        usuarioCreacion = c.String(nullable: false),
                        fechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.requerimientoDetalleEstadoRequerimientoDetalleId)
                .ForeignKey("dbo.EstadoRequerimientoDetalles", t => t.estadoRequerimientoDetalleId)
                .ForeignKey("dbo.RequerimientoDetalles", t => t.requerimientoDetalleId)
                .Index(t => t.requerimientoDetalleId)
                .Index(t => t.estadoRequerimientoDetalleId);
            
            CreateTable(
                "dbo.EstadoRequerimientoes",
                c => new
                    {
                        estadoRequerimientoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.estadoRequerimientoId);
            
            CreateTable(
                "dbo.RequerimientoEstadoRequerimientoes",
                c => new
                    {
                        requerimientoEstadoRequerimientoId = c.Int(nullable: false, identity: true),
                        requerimientoId = c.Int(nullable: false),
                        estadoRequerimientoId = c.Int(nullable: false),
                        usuarioCreacion = c.String(nullable: false),
                        fechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.requerimientoEstadoRequerimientoId)
                .ForeignKey("dbo.EstadoRequerimientoes", t => t.estadoRequerimientoId)
                .ForeignKey("dbo.Requerimientoes", t => t.requerimientoId)
                .Index(t => t.requerimientoId)
                .Index(t => t.estadoRequerimientoId);
            
            CreateTable(
                "dbo.OrdenServicios",
                c => new
                    {
                        ordenServicioId = c.Int(nullable: false, identity: true),
                        numero = c.String(nullable: false),
                        obraId = c.Int(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 20),
                        materialId = c.Int(nullable: false),
                        proveedorId = c.Int(nullable: false),
                        metrado = c.Double(nullable: false),
                        precioUnitario = c.Double(nullable: false),
                        subtotal = c.Double(nullable: false),
                        igv = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        formaPagoId = c.Int(nullable: false),
                        monedaId = c.Int(nullable: false),
                        adelanto = c.Double(),
                        adelantoPorc = c.Double(),
                        fondoGarantia = c.Double(),
                        fondoGarantiaPorc = c.Double(),
                        tipoValorizacionId = c.Int(nullable: false),
                        fechaInicio = c.DateTime(nullable: false),
                        duracion = c.Int(),
                        partidaId = c.Int(nullable: false),
                        requerimientoId = c.Int(nullable: false),
                        avance = c.Double(),
                        avancePorc = c.Double(),
                        saldo = c.Double(),
                        saldoPorc = c.Double(),
                        numeroPagos = c.Int(nullable: false),
                        comentario = c.String(maxLength: 1000),
                        usuarioCreacion = c.String(nullable: false),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ordenServicioId)
                .ForeignKey("dbo.FormaPagoes", t => t.formaPagoId)
                .ForeignKey("dbo.Materials", t => t.materialId)
                .ForeignKey("dbo.Monedas", t => t.monedaId)
                .ForeignKey("dbo.Obras", t => t.obraId)
                .ForeignKey("dbo.Partidas", t => t.partidaId)
                .ForeignKey("dbo.Proveedors", t => t.proveedorId)
                .ForeignKey("dbo.Requerimientoes", t => t.requerimientoId)
                .ForeignKey("dbo.TipoValorizacions", t => t.tipoValorizacionId)
                .Index(t => t.obraId)
                .Index(t => t.materialId)
                .Index(t => t.proveedorId)
                .Index(t => t.formaPagoId)
                .Index(t => t.monedaId)
                .Index(t => t.tipoValorizacionId)
                .Index(t => t.partidaId)
                .Index(t => t.requerimientoId);
            
            CreateTable(
                "dbo.OrdenServicioArchivoes",
                c => new
                    {
                        ordenServicioArchivoId = c.Int(nullable: false, identity: true),
                        ordenServicioId = c.Int(nullable: false),
                        archivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ordenServicioArchivoId)
                .ForeignKey("dbo.Archivoes", t => t.archivoId)
                .ForeignKey("dbo.OrdenServicios", t => t.ordenServicioId)
                .Index(t => t.ordenServicioId)
                .Index(t => t.archivoId);
            
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        archivoId = c.Int(nullable: false, identity: true),
                        tipoArchivoId = c.Int(nullable: false),
                        ruta = c.String(),
                    })
                .PrimaryKey(t => t.archivoId)
                .ForeignKey("dbo.TipoArchivoes", t => t.tipoArchivoId)
                .Index(t => t.tipoArchivoId);
            
            CreateTable(
                "dbo.TipoArchivoes",
                c => new
                    {
                        tipoArchivoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tipoArchivoId);
            
            CreateTable(
                "dbo.TipoValorizacions",
                c => new
                    {
                        tipoValorizacionId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tipoValorizacionId);
            
            CreateTable(
                "dbo.Valorizacions",
                c => new
                    {
                        valorizacionId = c.Int(nullable: false, identity: true),
                        ordenServicioId = c.Int(nullable: false),
                        concepto = c.String(),
                        fechacierre = c.DateTime(nullable: false),
                        avance = c.Double(nullable: false),
                        avancePorc = c.Double(nullable: false),
                        estadoValorizacionId = c.Int(nullable: false),
                        usuarioCreacion = c.String(nullable: false),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.valorizacionId)
                .ForeignKey("dbo.EstadoValorizacions", t => t.estadoValorizacionId)
                .ForeignKey("dbo.OrdenServicios", t => t.ordenServicioId)
                .Index(t => t.ordenServicioId)
                .Index(t => t.estadoValorizacionId);
            
            CreateTable(
                "dbo.EstadoValorizacions",
                c => new
                    {
                        estadoValorizacionId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.estadoValorizacionId);
            
            CreateTable(
                "dbo.Prioridads",
                c => new
                    {
                        prioridadId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        plazoDias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prioridadId);
            
            CreateTable(
                "dbo.TipoCompras",
                c => new
                    {
                        tipoCompraId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.tipoCompraId);
            
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
                "dbo.TipoPresupuestoes",
                c => new
                    {
                        tipoPresupuestoId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tipoPresupuestoId);
            
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
                        usuarioCreacion = c.String(nullable: false),
                        usuarioModificacion = c.String(),
                        fechaCreacion = c.DateTime(nullable: false),
                        fechaModificacion = c.DateTime(nullable: false),
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
                "dbo.Parametroes",
                c => new
                    {
                        parametroId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ultimoNumero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.parametroId);
            
            CreateTable(
                "dbo.PresupuestoTituloes",
                c => new
                    {
                        presupuestoId = c.Int(nullable: false),
                        tituloId = c.Int(nullable: false),
                        orden = c.Int(nullable: false),
                        subPresupuestoId = c.Int(nullable: false),
                        tituloIdPadre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.presupuestoId, t.tituloId })
                .ForeignKey("dbo.Presupuestoes", t => t.presupuestoId)
                .ForeignKey("dbo.SubPresupuestoes", t => t.subPresupuestoId)
                .ForeignKey("dbo.Tituloes", t => t.tituloId)
                .Index(t => t.presupuestoId)
                .Index(t => t.tituloId)
                .Index(t => t.subPresupuestoId);
            
            CreateTable(
                "dbo.TituloPresupuestoes",
                c => new
                    {
                        Titulo_tituloId = c.Int(nullable: false),
                        Presupuesto_presupuestoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Titulo_tituloId, t.Presupuesto_presupuestoId })
                .ForeignKey("dbo.Tituloes", t => t.Titulo_tituloId, cascadeDelete: true)
                .ForeignKey("dbo.Presupuestoes", t => t.Presupuesto_presupuestoId, cascadeDelete: true)
                .Index(t => t.Titulo_tituloId)
                .Index(t => t.Presupuesto_presupuestoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresupuestoTituloes", "tituloId", "dbo.Tituloes");
            DropForeignKey("dbo.PresupuestoTituloes", "subPresupuestoId", "dbo.SubPresupuestoes");
            DropForeignKey("dbo.PresupuestoTituloes", "presupuestoId", "dbo.Presupuestoes");
            DropForeignKey("dbo.MaterialNivelStocks", "materialId", "dbo.Materials");
            DropForeignKey("dbo.MaterialNivelStocks", "almacenId", "dbo.Almacens");
            DropForeignKey("dbo.IngresoDetalles", "ordenCompradetalleId", "dbo.OrdenCompraDetalles");
            DropForeignKey("dbo.Ingresoes", "ordenCompraId", "dbo.OrdenCompras");
            DropForeignKey("dbo.IngresoDetalles", "Ingreso_ingresoId", "dbo.Ingresoes");
            DropForeignKey("dbo.Ingresoes", "DocumentoPago_documentoPagoId", "dbo.DocumentoPagoes");
            DropForeignKey("dbo.DocumentoPagoes", "tipoDocumentoId", "dbo.TipoDocumentoes");
            DropForeignKey("dbo.Categorias", "categoriaPadreId", "dbo.Categorias");
            DropForeignKey("dbo.Almacens", "obraId", "dbo.Obras");
            DropForeignKey("dbo.TituloPresupuestoes", "Presupuesto_presupuestoId", "dbo.Presupuestoes");
            DropForeignKey("dbo.TituloPresupuestoes", "Titulo_tituloId", "dbo.Tituloes");
            DropForeignKey("dbo.Partidas", "Titulo_tituloId", "dbo.Tituloes");
            DropForeignKey("dbo.Presupuestoes", "tipoPresupuestoId", "dbo.TipoPresupuestoes");
            DropForeignKey("dbo.PresupuestoDetalles", "presupuestoId", "dbo.Presupuestoes");
            DropForeignKey("dbo.PresupuestoDetalles", "materialId", "dbo.Materials");
            DropForeignKey("dbo.Presupuestoes", "obraId", "dbo.Obras");
            DropForeignKey("dbo.Presupuestoes", "monedaId", "dbo.Monedas");
            DropForeignKey("dbo.Requerimientoes", "tipoCompraId", "dbo.TipoCompras");
            DropForeignKey("dbo.Requerimientoes", "prioridadId", "dbo.Prioridads");
            DropForeignKey("dbo.Valorizacions", "ordenServicioId", "dbo.OrdenServicios");
            DropForeignKey("dbo.Valorizacions", "estadoValorizacionId", "dbo.EstadoValorizacions");
            DropForeignKey("dbo.OrdenServicios", "tipoValorizacionId", "dbo.TipoValorizacions");
            DropForeignKey("dbo.OrdenServicios", "requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.OrdenServicios", "proveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenServicios", "partidaId", "dbo.Partidas");
            DropForeignKey("dbo.OrdenServicioArchivoes", "ordenServicioId", "dbo.OrdenServicios");
            DropForeignKey("dbo.OrdenServicioArchivoes", "archivoId", "dbo.Archivoes");
            DropForeignKey("dbo.Archivoes", "tipoArchivoId", "dbo.TipoArchivoes");
            DropForeignKey("dbo.OrdenServicios", "obraId", "dbo.Obras");
            DropForeignKey("dbo.OrdenServicios", "monedaId", "dbo.Monedas");
            DropForeignKey("dbo.OrdenServicios", "materialId", "dbo.Materials");
            DropForeignKey("dbo.OrdenServicios", "formaPagoId", "dbo.FormaPagoes");
            DropForeignKey("dbo.OrdenCompras", "requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.Requerimientoes", "obraId", "dbo.Obras");
            DropForeignKey("dbo.Requerimientoes", "estadoRequerimientoId", "dbo.EstadoRequerimientoes");
            DropForeignKey("dbo.RequerimientoEstadoRequerimientoes", "requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.RequerimientoEstadoRequerimientoes", "estadoRequerimientoId", "dbo.EstadoRequerimientoes");
            DropForeignKey("dbo.RequerimientoDetalleEstadoRequerimientoDetalles", "requerimientoDetalleId", "dbo.RequerimientoDetalles");
            DropForeignKey("dbo.RequerimientoDetalleEstadoRequerimientoDetalles", "estadoRequerimientoDetalleId", "dbo.EstadoRequerimientoDetalles");
            DropForeignKey("dbo.RequerimientoDetalles", "requerimientoId", "dbo.Requerimientoes");
            DropForeignKey("dbo.RequerimientoDetalles", "partidaId", "dbo.Partidas");
            DropForeignKey("dbo.Partidas", "subPresupuestoId", "dbo.SubPresupuestoes");
            DropForeignKey("dbo.RequerimientoDetalles", "ordenCompraId", "dbo.OrdenCompras");
            DropForeignKey("dbo.RequerimientoDetalles", "materialId", "dbo.Materials");
            DropForeignKey("dbo.RequerimientoDetalles", "estadoRequerimientoDetalleId", "dbo.EstadoRequerimientoDetalles");
            DropForeignKey("dbo.OrdenCompras", "proveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.OrdenCompraDetalles", "ordenCompraId", "dbo.OrdenCompras");
            DropForeignKey("dbo.Materials", "unidadMedidaId", "dbo.UnidadMedidas");
            DropForeignKey("dbo.Materials", "tipoMaterialId", "dbo.TipoMaterials");
            DropForeignKey("dbo.OrdenCompraDetalles", "materialId", "dbo.Materials");
            DropForeignKey("dbo.Materials", "materialPadreId", "dbo.Materials");
            DropForeignKey("dbo.OrdenCompraDetalles", "estadoOrdenDetalleId", "dbo.EstadoOrdenDetalles");
            DropForeignKey("dbo.OrdenCompraEstadoOrdens", "ordenCompraId", "dbo.OrdenCompras");
            DropForeignKey("dbo.OrdenCompraEstadoOrdens", "estadoOrdenId", "dbo.EstadoOrdens");
            DropForeignKey("dbo.OrdenCompras", "obraId", "dbo.Obras");
            DropForeignKey("dbo.OrdenCompras", "monedaId", "dbo.Monedas");
            DropForeignKey("dbo.OrdenCompras", "formaPagoId", "dbo.FormaPagoes");
            DropForeignKey("dbo.OrdenCompras", "estadoOrdenId", "dbo.EstadoOrdens");
            DropForeignKey("dbo.Obras", "empresaId", "dbo.Empresas");
            DropIndex("dbo.TituloPresupuestoes", new[] { "Presupuesto_presupuestoId" });
            DropIndex("dbo.TituloPresupuestoes", new[] { "Titulo_tituloId" });
            DropIndex("dbo.PresupuestoTituloes", new[] { "subPresupuestoId" });
            DropIndex("dbo.PresupuestoTituloes", new[] { "tituloId" });
            DropIndex("dbo.PresupuestoTituloes", new[] { "presupuestoId" });
            DropIndex("dbo.MaterialNivelStocks", new[] { "materialId" });
            DropIndex("dbo.MaterialNivelStocks", new[] { "almacenId" });
            DropIndex("dbo.Ingresoes", new[] { "DocumentoPago_documentoPagoId" });
            DropIndex("dbo.Ingresoes", new[] { "ordenCompraId" });
            DropIndex("dbo.IngresoDetalles", new[] { "Ingreso_ingresoId" });
            DropIndex("dbo.IngresoDetalles", new[] { "ordenCompradetalleId" });
            DropIndex("dbo.DocumentoPagoes", new[] { "tipoDocumentoId" });
            DropIndex("dbo.Categorias", new[] { "categoriaPadreId" });
            DropIndex("dbo.PresupuestoDetalles", new[] { "materialId" });
            DropIndex("dbo.PresupuestoDetalles", new[] { "presupuestoId" });
            DropIndex("dbo.Valorizacions", new[] { "estadoValorizacionId" });
            DropIndex("dbo.Valorizacions", new[] { "ordenServicioId" });
            DropIndex("dbo.Archivoes", new[] { "tipoArchivoId" });
            DropIndex("dbo.OrdenServicioArchivoes", new[] { "archivoId" });
            DropIndex("dbo.OrdenServicioArchivoes", new[] { "ordenServicioId" });
            DropIndex("dbo.OrdenServicios", new[] { "requerimientoId" });
            DropIndex("dbo.OrdenServicios", new[] { "partidaId" });
            DropIndex("dbo.OrdenServicios", new[] { "tipoValorizacionId" });
            DropIndex("dbo.OrdenServicios", new[] { "monedaId" });
            DropIndex("dbo.OrdenServicios", new[] { "formaPagoId" });
            DropIndex("dbo.OrdenServicios", new[] { "proveedorId" });
            DropIndex("dbo.OrdenServicios", new[] { "materialId" });
            DropIndex("dbo.OrdenServicios", new[] { "obraId" });
            DropIndex("dbo.RequerimientoEstadoRequerimientoes", new[] { "estadoRequerimientoId" });
            DropIndex("dbo.RequerimientoEstadoRequerimientoes", new[] { "requerimientoId" });
            DropIndex("dbo.RequerimientoDetalleEstadoRequerimientoDetalles", new[] { "estadoRequerimientoDetalleId" });
            DropIndex("dbo.RequerimientoDetalleEstadoRequerimientoDetalles", new[] { "requerimientoDetalleId" });
            DropIndex("dbo.Partidas", new[] { "Titulo_tituloId" });
            DropIndex("dbo.Partidas", new[] { "subPresupuestoId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "ordenCompraId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "estadoRequerimientoDetalleId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "partidaId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "materialId" });
            DropIndex("dbo.RequerimientoDetalles", new[] { "requerimientoId" });
            DropIndex("dbo.Requerimientoes", new[] { "estadoRequerimientoId" });
            DropIndex("dbo.Requerimientoes", new[] { "tipoCompraId" });
            DropIndex("dbo.Requerimientoes", new[] { "prioridadId" });
            DropIndex("dbo.Requerimientoes", new[] { "obraId" });
            DropIndex("dbo.Materials", new[] { "materialPadreId" });
            DropIndex("dbo.Materials", new[] { "tipoMaterialId" });
            DropIndex("dbo.Materials", new[] { "unidadMedidaId" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "estadoOrdenDetalleId" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "materialId" });
            DropIndex("dbo.OrdenCompraDetalles", new[] { "ordenCompraId" });
            DropIndex("dbo.OrdenCompraEstadoOrdens", new[] { "estadoOrdenId" });
            DropIndex("dbo.OrdenCompraEstadoOrdens", new[] { "ordenCompraId" });
            DropIndex("dbo.OrdenCompras", new[] { "monedaId" });
            DropIndex("dbo.OrdenCompras", new[] { "formaPagoId" });
            DropIndex("dbo.OrdenCompras", new[] { "requerimientoId" });
            DropIndex("dbo.OrdenCompras", new[] { "estadoOrdenId" });
            DropIndex("dbo.OrdenCompras", new[] { "obraId" });
            DropIndex("dbo.OrdenCompras", new[] { "proveedorId" });
            DropIndex("dbo.Presupuestoes", new[] { "tipoPresupuestoId" });
            DropIndex("dbo.Presupuestoes", new[] { "monedaId" });
            DropIndex("dbo.Presupuestoes", new[] { "obraId" });
            DropIndex("dbo.Obras", new[] { "empresaId" });
            DropIndex("dbo.Almacens", new[] { "obraId" });
            DropTable("dbo.TituloPresupuestoes");
            DropTable("dbo.PresupuestoTituloes");
            DropTable("dbo.Parametroes");
            DropTable("dbo.MaterialNivelStocks");
            DropTable("dbo.Ingresoes");
            DropTable("dbo.IngresoDetalles");
            DropTable("dbo.TipoDocumentoes");
            DropTable("dbo.DocumentoPagoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Tituloes");
            DropTable("dbo.TipoPresupuestoes");
            DropTable("dbo.PresupuestoDetalles");
            DropTable("dbo.TipoCompras");
            DropTable("dbo.Prioridads");
            DropTable("dbo.EstadoValorizacions");
            DropTable("dbo.Valorizacions");
            DropTable("dbo.TipoValorizacions");
            DropTable("dbo.TipoArchivoes");
            DropTable("dbo.Archivoes");
            DropTable("dbo.OrdenServicioArchivoes");
            DropTable("dbo.OrdenServicios");
            DropTable("dbo.RequerimientoEstadoRequerimientoes");
            DropTable("dbo.EstadoRequerimientoes");
            DropTable("dbo.RequerimientoDetalleEstadoRequerimientoDetalles");
            DropTable("dbo.SubPresupuestoes");
            DropTable("dbo.Partidas");
            DropTable("dbo.EstadoRequerimientoDetalles");
            DropTable("dbo.RequerimientoDetalles");
            DropTable("dbo.Requerimientoes");
            DropTable("dbo.Proveedors");
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.TipoMaterials");
            DropTable("dbo.Materials");
            DropTable("dbo.EstadoOrdenDetalles");
            DropTable("dbo.OrdenCompraDetalles");
            DropTable("dbo.OrdenCompraEstadoOrdens");
            DropTable("dbo.FormaPagoes");
            DropTable("dbo.EstadoOrdens");
            DropTable("dbo.OrdenCompras");
            DropTable("dbo.Monedas");
            DropTable("dbo.Presupuestoes");
            DropTable("dbo.Empresas");
            DropTable("dbo.Obras");
            DropTable("dbo.Almacens");
        }
    }
}
