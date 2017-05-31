namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenServicios", "duracion", c => c.Int());
            CreateIndex("dbo.OrdenServicios", "partidaId");
            AddForeignKey("dbo.OrdenServicios", "partidaId", "dbo.Partidas", "partidaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenServicios", "partidaId", "dbo.Partidas");
            DropIndex("dbo.OrdenServicios", new[] { "partidaId" });
            DropColumn("dbo.OrdenServicios", "duracion");
        }
    }
}
