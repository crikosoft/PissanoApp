namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.TituloPartidas", "Partida_partidaId", "dbo.Partidas");
            DropForeignKey("dbo.TituloPartidas", "Titulo_tituloId", "dbo.Tituloes");
            DropIndex("dbo.TituloPartidas", new[] { "Partida_partidaId" });
            DropIndex("dbo.TituloPartidas", new[] { "Titulo_tituloId" });
            DropTable("dbo.TituloPartidas");
            DropTable("dbo.Tituloes");
            DropTable("dbo.Partidas");
        }
    }
}
