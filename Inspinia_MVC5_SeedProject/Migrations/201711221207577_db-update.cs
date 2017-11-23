namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagoes", "fechaFactura", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagoes", "fechaFactura");
        }
    }
}
