namespace PissanoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contratoes", "saldoMonto", c => c.Double());
            DropColumn("dbo.Contratoes", "saldo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contratoes", "saldo", c => c.Double());
            DropColumn("dbo.Contratoes", "saldoMonto");
        }
    }
}
