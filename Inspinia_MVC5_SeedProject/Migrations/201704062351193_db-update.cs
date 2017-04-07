namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Materials", "RequerimientoViewModel_requerimientoViewModelId", "dbo.RequerimientoViewModels");
            DropForeignKey("dbo.Obras", "RequerimientoViewModel_requerimientoViewModelId", "dbo.RequerimientoViewModels");
            DropForeignKey("dbo.Prioridads", "RequerimientoViewModel_requerimientoViewModelId", "dbo.RequerimientoViewModels");
            DropIndex("dbo.Obras", new[] { "RequerimientoViewModel_requerimientoViewModelId" });
            DropIndex("dbo.Materials", new[] { "RequerimientoViewModel_requerimientoViewModelId" });
            DropIndex("dbo.Prioridads", new[] { "RequerimientoViewModel_requerimientoViewModelId" });
            DropColumn("dbo.Obras", "RequerimientoViewModel_requerimientoViewModelId");
            DropColumn("dbo.Materials", "RequerimientoViewModel_requerimientoViewModelId");
            DropColumn("dbo.Prioridads", "RequerimientoViewModel_requerimientoViewModelId");
            DropTable("dbo.RequerimientoViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RequerimientoViewModels",
                c => new
                    {
                        requerimientoViewModelId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.requerimientoViewModelId);
            
            AddColumn("dbo.Prioridads", "RequerimientoViewModel_requerimientoViewModelId", c => c.Int());
            AddColumn("dbo.Materials", "RequerimientoViewModel_requerimientoViewModelId", c => c.Int());
            AddColumn("dbo.Obras", "RequerimientoViewModel_requerimientoViewModelId", c => c.Int());
            CreateIndex("dbo.Prioridads", "RequerimientoViewModel_requerimientoViewModelId");
            CreateIndex("dbo.Materials", "RequerimientoViewModel_requerimientoViewModelId");
            CreateIndex("dbo.Obras", "RequerimientoViewModel_requerimientoViewModelId");
            AddForeignKey("dbo.Prioridads", "RequerimientoViewModel_requerimientoViewModelId", "dbo.RequerimientoViewModels", "requerimientoViewModelId");
            AddForeignKey("dbo.Obras", "RequerimientoViewModel_requerimientoViewModelId", "dbo.RequerimientoViewModels", "requerimientoViewModelId");
            AddForeignKey("dbo.Materials", "RequerimientoViewModel_requerimientoViewModelId", "dbo.RequerimientoViewModels", "requerimientoViewModelId");
        }
    }
}
