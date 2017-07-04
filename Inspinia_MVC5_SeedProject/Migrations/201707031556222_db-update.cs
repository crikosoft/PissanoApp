namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movimientoes", "Material_materialId", "dbo.Materials");
            DropIndex("dbo.Movimientoes", new[] { "Material_materialId" });
            DropColumn("dbo.Movimientoes", "Material_materialId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movimientoes", "Material_materialId", c => c.Int());
            CreateIndex("dbo.Movimientoes", "Material_materialId");
            AddForeignKey("dbo.Movimientoes", "Material_materialId", "dbo.Materials", "materialId");
        }
    }
}
