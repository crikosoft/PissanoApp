using Microsoft.AspNet.Identity.EntityFramework;
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


            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            //modelBuilder.Entity<Requerimiento>().
            //    HasOptional(a => a.Detalles).
            //    WithOptionalDependent().
            //    WillCascadeOnDelete(true);

            //No se usa
            //modelBuilder.Entity<Presupuesto>()
            //            .HasMany<Titulo>(s => s.Titulos)
            //            .WithMany(c => c.Presupuestos)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("presupuestoId");
            //                cs.MapRightKey("tituloId");
            //                cs.ToTable("PresupuestoTitulo");
            //            });


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

        //public System.Data.Entity.DbSet<PissanoApp.ViewModels.PresupuestoPartidaViewModel> PresupuestoPartidaViewModels { get; set; }

        //public System.Data.Entity.DbSet<PissanoApp.ViewModels.PresupuestoTitulosViewModel> PresupuestoTitulosViewModels { get; set; }

        public DbSet<PresupuestoTitulo> PresupuestoTitulo { get; set; }

        public DbSet<SubPresupuesto> SubPresupuesto { get; set; }

        public DbSet<Prioridad> Prioridad { get; set; }

        public DbSet<TipoCompra> TipoCompra { get; set; }

        public DbSet<EstadoRequerimiento> EstadoRequerimiento { get; set; }

        public DbSet<EstadoRequerimientoDetalle> EstadoRequerimientoDetalle { get; set; }


        public DbSet<Parametro> Parametro { get; set; }

        public DbSet<RequerimientoEstadoRequerimiento> RequerimientoEstadoRequerimiento { get; set; }

        public DbSet<RequerimientoDetalleEstadoRequerimientoDetalle> RequerimientoDetalleEstadoRequerimientoDetalle { get; set; }

        public DbSet<OrdenCompraEstadoOrden> OrdenCompraEstadoOrden { get; set; }

        public DbSet<Archivo> Archivo { get; set; }

        public DbSet<TipoArchivo> TipoArchivo { get; set; }

        //Contrato y Valoriación
        public DbSet<Contrato> Contrato { get; set; }

        public DbSet<Valorizacion> Valorizacion { get; set; }

        public DbSet<TipoValorizacion> TipoValorizacion { get; set; }

        public DbSet<EstadoValorizacion> EstadosValorizacion { get; set; }

       
    }


    //public class MyDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public MyDbContext()
    //        : base("IdentityConnection")
    //    {
    //    }



    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        // Change the name of the table to be Users instead of AspNetUsers
    //        modelBuilder.Entity<IdentityUser>()
    //            .ToTable("AspNetUsers");
    //        modelBuilder.Entity<ApplicationUser>()
    //            .ToTable("AspNetUsers");

    //    }

    //    public DbSet<ToDo> ToDoes { get; set; }

    //    public DbSet<MyUserInfo> MyUserInfo { get; set; }
    //}


    //public class MyUserInfo
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    //public class ToDo
    //{
    //    public int Id { get; set; }
    //    public string Description { get; set; }
    //    public bool IsDone { get; set; }
    //    public virtual ApplicationUser User { get; set; }
    //}

}