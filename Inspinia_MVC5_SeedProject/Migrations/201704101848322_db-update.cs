namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoCompras",
                c => new
                    {
                        tipoCompraId = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.tipoCompraId);
            
            AddColumn("dbo.Requerimientoes", "tipoCompraId", c => c.Int());
            CreateIndex("dbo.Requerimientoes", "tipoCompraId");
            AddForeignKey("dbo.Requerimientoes", "tipoCompraId", "dbo.TipoCompras", "tipoCompraId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requerimientoes", "tipoCompraId", "dbo.TipoCompras");
            DropIndex("dbo.Requerimientoes", new[] { "tipoCompraId" });
            DropColumn("dbo.Requerimientoes", "tipoCompraId");
            DropTable("dbo.TipoCompras");
        }
    }
}
