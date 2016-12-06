namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proveedorcomprador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompIdFiscalProvComprador", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompProveedorComprador", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompValorMonedaExt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompValorDolares", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomCalle", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomNumExterior", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomNumInterior", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomCdMunicipio", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomCP", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomPais", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompPaisClave", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompPaisDesc", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompMonedaClave", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "ProvCompMonedaDesc", c => c.String());
            DropColumn("dbo.DsPedimento", "DatosProvCompIdFiscalProvComprador");
            DropColumn("dbo.DsPedimento", "DatosProvCompProveedorComprador");
            DropColumn("dbo.DsPedimento", "DatosProvCompValorMonedaExt");
            DropColumn("dbo.DsPedimento", "DatosProvCompValorDolares");
            DropColumn("dbo.DsPedimento", "DatosProvCompPaisClave");
            DropColumn("dbo.DsPedimento", "DatosProvCompPaisDesc");
            DropColumn("dbo.DsPedimento", "DatosProvCompMonedaClave");
            DropColumn("dbo.DsPedimento", "DatosProvCompMonedaDesc");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompIdFiscalProvComprador");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompProveedorComprador");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompValorMonedaExt");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompValorDolares");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomCalle");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomNumExterior");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomNumInterior");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomCdMunicipio");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomCP");
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompPais");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompPais", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomCP", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomCdMunicipio", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomNumInterior", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomNumExterior", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompDomCalle", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompValorDolares", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompValorMonedaExt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompProveedorComprador", c => c.String());
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompIdFiscalProvComprador", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompMonedaDesc", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompMonedaClave", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompPaisDesc", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompPaisClave", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompValorDolares", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompValorMonedaExt", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompProveedorComprador", c => c.String());
            AddColumn("dbo.DsPedimento", "DatosProvCompIdFiscalProvComprador", c => c.String());
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompMonedaDesc");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompMonedaClave");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompPaisDesc");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompPaisClave");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomPais");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomCP");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomCdMunicipio");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomNumInterior");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomNumExterior");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompDomCalle");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompValorDolares");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompValorMonedaExt");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompProveedorComprador");
            DropColumn("dbo.DsPedimentoProveedorComprador", "ProvCompIdFiscalProvComprador");
        }
    }
}
