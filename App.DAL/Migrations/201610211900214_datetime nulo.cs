namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenulo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DsPartidaCuentaAduanera", "FechaConstancia", c => c.DateTime());
            AlterColumn("dbo.DsPedimentoCuentaAduanera", "FechaConstancia", c => c.DateTime());
            AlterColumn("dbo.DsPedimentoDescargo", "FechaPagoOriginal", c => c.DateTime());
            AlterColumn("dbo.DsPedimentoFactura", "FechaFacturacion", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DsPedimentoFactura", "FechaFacturacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DsPedimentoDescargo", "FechaPagoOriginal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DsPedimentoCuentaAduanera", "FechaConstancia", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DsPartidaCuentaAduanera", "FechaConstancia", c => c.DateTime(nullable: false));
        }
    }
}
