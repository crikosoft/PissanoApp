namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contratoes", "usuarioCreacion", c => c.String());
            AlterColumn("dbo.Contratoes", "fechaCreacion", c => c.DateTime());
            AlterColumn("dbo.Contratoes", "fechaModificacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contratoes", "fechaModificacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contratoes", "fechaCreacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contratoes", "usuarioCreacion", c => c.String(nullable: false));
        }
    }
}
