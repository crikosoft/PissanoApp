namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TituloPartidas", newName: "PartidaTituloes");
            DropPrimaryKey("dbo.PartidaTituloes");
            CreateTable(
                "dbo.PresupuestoTitulo",
                c => new
                    {
                        presupuestoId = c.Int(nullable: false),
                        tituloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.presupuestoId, t.tituloId })
                .ForeignKey("dbo.Presupuestoes", t => t.presupuestoId, cascadeDelete: true)
                .ForeignKey("dbo.Tituloes", t => t.tituloId, cascadeDelete: true)
                .Index(t => t.presupuestoId)
                .Index(t => t.tituloId);
            
            AddPrimaryKey("dbo.PartidaTituloes", new[] { "Partida_partidaId", "Titulo_tituloId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresupuestoTitulo", "tituloId", "dbo.Tituloes");
            DropForeignKey("dbo.PresupuestoTitulo", "presupuestoId", "dbo.Presupuestoes");
            DropIndex("dbo.PresupuestoTitulo", new[] { "tituloId" });
            DropIndex("dbo.PresupuestoTitulo", new[] { "presupuestoId" });
            DropPrimaryKey("dbo.PartidaTituloes");
            DropTable("dbo.PresupuestoTitulo");
            AddPrimaryKey("dbo.PartidaTituloes", new[] { "Titulo_tituloId", "Partida_partidaId" });
            RenameTable(name: "dbo.PartidaTituloes", newName: "TituloPartidas");
        }
    }
}
