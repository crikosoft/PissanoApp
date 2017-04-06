namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Obras", "nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Obras", "nombre");
        }
    }
}
