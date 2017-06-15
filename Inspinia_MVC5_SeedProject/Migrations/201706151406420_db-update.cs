namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequerimientoDetalles", "cantidad", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequerimientoDetalles", "cantidad", c => c.Int(nullable: false));
        }
    }
}
