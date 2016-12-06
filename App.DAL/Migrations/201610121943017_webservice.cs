namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webservice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DsPedimento", "ObservacionesPedimento", c => c.String());
            AlterColumn("dbo.DsPedimento", "EncabezadoOpDesc", c => c.String());
            AlterColumn("dbo.DsPedimento", "EncabezadoClavDocDescripcion", c => c.String());
            AlterColumn("dbo.DsPedimento", "EncabezadoDestionDesc", c => c.String());
            AlterColumn("dbo.DsPedimento", "EncabezadoMedTranspSalDesc", c => c.String());
            AlterColumn("dbo.DsPedimento", "EncabezadoMedTranspArriboDesc", c => c.String());
            AlterColumn("dbo.DsPedimento", "EncabezadoMedTranspEntradaDesc", c => c.String());
            AlterColumn("dbo.DsPedimento", "RFCAduanalSocFactura", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpRazSocImpExp", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpDomCalle", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpNumDomExterior", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpNumDomInterior", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpDomCdMunicipio", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpDomCP", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpAudoDespachoDesc", c => c.String());
            AlterColumn("dbo.DsPedimento", "ImpExpPaisDesc", c => c.String());
            AlterColumn("dbo.DsPartida", "DescMercancia", c => c.String());
            AlterColumn("dbo.DsPartida", "UnidadMedTarifaDesc", c => c.String());
            AlterColumn("dbo.DsPartida", "UnidadMedComerDesc", c => c.String());
            AlterColumn("dbo.DsPartida", "MetodoValorDesc", c => c.String());
            AlterColumn("dbo.DsPartida", "VinculacionDesc", c => c.String());
            AlterColumn("dbo.DsPartida", "PaisOrigDestDesc", c => c.String());
            AlterColumn("dbo.DsPartida", "PaisVendCompDesc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DsPartida", "PaisVendCompDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPartida", "PaisOrigDestDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPartida", "VinculacionDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPartida", "MetodoValorDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPartida", "UnidadMedComerDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPartida", "UnidadMedTarifaDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPartida", "DescMercancia", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "ImpExpPaisDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "ImpExpAudoDespachoDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "ImpExpDomCP", c => c.String(maxLength: 10));
            AlterColumn("dbo.DsPedimento", "ImpExpDomCdMunicipio", c => c.String(maxLength: 80));
            AlterColumn("dbo.DsPedimento", "ImpExpNumDomInterior", c => c.String(maxLength: 10));
            AlterColumn("dbo.DsPedimento", "ImpExpNumDomExterior", c => c.String(maxLength: 10));
            AlterColumn("dbo.DsPedimento", "ImpExpDomCalle", c => c.String(maxLength: 80));
            AlterColumn("dbo.DsPedimento", "ImpExpRazSocImpExp", c => c.String(maxLength: 120));
            AlterColumn("dbo.DsPedimento", "RFCAduanalSocFactura", c => c.String(maxLength: 13));
            AlterColumn("dbo.DsPedimento", "EncabezadoMedTranspEntradaDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "EncabezadoMedTranspArriboDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "EncabezadoMedTranspSalDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "EncabezadoDestionDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "EncabezadoClavDocDescripcion", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "EncabezadoOpDesc", c => c.String(maxLength: 250));
            AlterColumn("dbo.DsPedimento", "ObservacionesPedimento", c => c.String(maxLength: 120));
        }
    }
}
