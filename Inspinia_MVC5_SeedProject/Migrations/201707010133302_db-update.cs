namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Archivoes", "Contrato_contratoId", "dbo.Contratoes");
            DropIndex("dbo.Archivoes", new[] { "Contrato_contratoId" });
            DropColumn("dbo.Archivoes", "Contrato_contratoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Archivoes", "Contrato_contratoId", c => c.Int());
            CreateIndex("dbo.Archivoes", "Contrato_contratoId");
            AddForeignKey("dbo.Archivoes", "Contrato_contratoId", "dbo.Contratoes", "contratoId");
        }
    }
}
