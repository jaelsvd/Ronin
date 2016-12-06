namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provedorcomprador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DsPedimentoProveedorComprador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatosProvCompIdFiscalProvComprador = c.String(),
                        DatosProvCompProveedorComprador = c.String(),
                        DatosProvCompValorMonedaExt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatosProvCompValorDolares = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatosProvCompDomCalle = c.String(),
                        DatosProvCompDomNumExterior = c.String(),
                        DatosProvCompDomNumInterior = c.String(),
                        DatosProvCompDomCdMunicipio = c.String(),
                        DatosProvCompDomCP = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            DropColumn("dbo.DsPedimento", "DatosProvCompDomCalle");
            DropColumn("dbo.DsPedimento", "DatosProvCompDomNumExterior");
            DropColumn("dbo.DsPedimento", "DatosProvCompDomNumInterior");
            DropColumn("dbo.DsPedimento", "DatosProvCompDomCdMunicipio");
            DropColumn("dbo.DsPedimento", "DatosProvCompDomCP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DsPedimento", "DatosProvCompDomCP", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompDomCdMunicipio", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompDomNumInterior", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompDomNumExterior", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompDomCalle", c => c.String());
            DropForeignKey("dbo.DsPedimentoProveedorComprador", "PedimentoId", "dbo.DsPedimento");
            DropIndex("dbo.DsPedimentoProveedorComprador", new[] { "PedimentoId" });
            DropTable("dbo.DsPedimentoProveedorComprador");
        }
    }
}
