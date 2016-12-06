namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechasDelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DsPedimentoIdentificador", "FechaCreacion");
            DropColumn("dbo.DsPartidaImporte", "FechaCreacion");
            DropColumn("dbo.DsPartidaTasa", "FechaCreacion");
            DropColumn("dbo.DsPedimentoImpExpFechas", "FechaCreacion");
            DropColumn("dbo.DsPedimentoTasa", "FechaCreacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DsPedimentoTasa", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.DsPedimentoImpExpFechas", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.DsPartidaTasa", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.DsPartidaImporte", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.DsPedimentoIdentificador", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
