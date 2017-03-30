using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PissanoApp.Models
{
    public class PissanoContext : DbContext
    {

        //You can either disable it for your entire context by removing the cascade delete convention in the OnModelCreating method:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().
              HasOptional(e => e.CategoriaPadre).
              WithMany().
              HasForeignKey(m => m.categoriaPadreId);

            modelBuilder.Entity<Material>().
              HasOptional(e => e.MaterialPadre).
              WithMany().
              HasForeignKey(m => m.materialPadreId);

        }

        public PissanoContext() : base("DefaultConnection") { }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Obra> Obras { get; set; }

        public DbSet<UnidadMedida> UnidadMedidas { get; set; }

        public DbSet<TipoMaterial> TipoMateriales { get; set; }

        public DbSet<Material> Materiales { get; set; }

        public DbSet<Presupuesto> Presupuestos { get; set; }

        public DbSet<PresupuestoDetalle> PresupuestoDetalles { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Requerimiento> Requerimientos { get; set; }

        public DbSet<RequerimientoDetalle> RequerimientoDetalles { get; set; }

        public DbSet<EstadoOrden> EstadoOrdenes { get; set; }

        public DbSet<EstadoOrdenDetalle> EstadoOrdenDetalles { get; set; }

        public DbSet<OrdenCompra> Ordenes { get; set; }

        public DbSet<OrdenCompraDetalle> OrdenDetalles { get; set; }

        public DbSet<FormaPago> FormaPagos { get; set; }

        public DbSet<TipoDocumento> TipoDocumentos { get; set; }

        public DbSet<Ingreso> Ingresos { get; set; }

        public DbSet<IngresoDetalle> IngresoDetalles { get; set; }

        public DbSet<DocumentoPago> DocumentoPagos { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<MaterialNivelStock> MaterialNivelStock { get; set; }

        public System.Data.Entity.DbSet<PissanoApp.Models.Almacen> Almacens { get; set; }

        public System.Data.Entity.DbSet<PissanoApp.Models.Moneda> Monedas { get; set; }

        public System.Data.Entity.DbSet<PissanoApp.Models.TipoPresupuesto> TipoPresupuestoes { get; set; }

        //public System.Data.Entity.DbSet<PissanoApp.ViewModels.PresupuestoViewModel> PresupuestoViewModels { get; set; }

        //public System.Data.Entity.DbSet<PissanoApp.ViewModels.PresupuestoViewModel> PresupuestoViewModels { get; set; }


        public DbSet<Titulo> Titulo { get; set; }

        public DbSet<Partida> Partida { get; set; }

        //public System.Data.Entity.DbSet<PissanoApp.ViewModels.PresupuestoTitulosViewModel> PresupuestoTitulosViewModels { get; set; }

    }


}