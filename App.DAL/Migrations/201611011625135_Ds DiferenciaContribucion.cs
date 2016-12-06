namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DsDiferenciaContribucion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PedimentoDiferenciaContribucion", newName: "DsPedimentoDiferenciaContribucion");
            AlterColumn("dbo.DsPedimentoImpExpFechas", "ImpExpFechasFechaTipoDesc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DsPedimentoImpExpFechas", "ImpExpFechasFechaTipoDesc", c => c.String(maxLength: 250));
            RenameTable(name: "dbo.DsPedimentoDiferenciaContribucion", newName: "PedimentoDiferenciaContribucion");
        }
    }
}
