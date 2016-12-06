namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DsListaPedimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieneError = c.Boolean(nullable: false),
                        ErrorDesc = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        ErrorPeticion = c.Boolean(nullable: false),
                        Tiempo = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DsPedimentosLista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieneError = c.Boolean(nullable: false),
                        AduanaClave = c.String(),
                        AduanaDesc = c.String(),
                        Patente = c.Int(nullable: false),
                        FolioPedimento = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        ListaPedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsListaPedimento", t => t.ListaPedimentoId, cascadeDelete: true)
                .Index(t => t.ListaPedimentoId);
            
            CreateTable(
                "dbo.DsPartidaIdentificador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificadorClaveIdentificadorClave = c.String(maxLength: 2),
                        IdentificadorClaveIdentificadorDesc = c.String(maxLength: 250),
                        IdentificadorComplemento1 = c.String(maxLength: 20),
                        IdentificadorComplemento2 = c.String(maxLength: 30),
                        IdentificadorComplemento3 = c.String(maxLength: 40),
                        FechaCreacion = c.DateTime(nullable: false),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.DsPartida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroPartida = c.Int(nullable: false),
                        FraccionArancelaria = c.String(maxLength: 8),
                        DescMercancia = c.String(maxLength: 250),
                        UnidadMedTarifaClave = c.String(),
                        UnidadMedTarifaDesc = c.String(maxLength: 250),
                        CantidadUnidadMedidaTarifa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnidadMedComerClave = c.String(),
                        UnidadMedComerDesc = c.String(maxLength: 250),
                        CantidadUnidadMedidaComercial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioUnitaro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorComercial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorAduana = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorDolares = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorAgregado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MetodoValorDesc = c.String(maxLength: 250),
                        VinculacionDesc = c.String(maxLength: 250),
                        PaisOrigDestClave = c.String(maxLength: 3),
                        PaisOrigDestDesc = c.String(maxLength: 250),
                        PaisVendCompClave = c.String(maxLength: 3),
                        PaisVendCompDesc = c.String(maxLength: 250),
                        ObservacionesDesc = c.String(),
                        TieneError = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPartidaGravamen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaveGravamenClave = c.Int(nullable: false),
                        ClaveGravamenDesc = c.String(maxLength: 250),
                        TieneError = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.DsPartidaImporte",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormaPagoClave = c.Int(nullable: false),
                        FormaPagoDesc = c.String(maxLength: 250),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TieneError = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PartidaGravamenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartidaGravamen", t => t.PartidaGravamenId, cascadeDelete: true)
                .Index(t => t.PartidaGravamenId);
            
            CreateTable(
                "dbo.DsPartidaTasa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TasaClave = c.Int(nullable: false),
                        TasaDesc = c.String(maxLength: 250),
                        TasaAplicable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TieneError = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        PartidaGravamenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartidaGravamen", t => t.PartidaGravamenId, cascadeDelete: true)
                .Index(t => t.PartidaGravamenId);
            
            CreateTable(
                "dbo.DsPedimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieneError = c.Boolean(nullable: false),
                        NumPedimento = c.String(maxLength: 7),
                        ObservacionesPedimento = c.String(maxLength: 120),
                        CantidadPartidas = c.Int(nullable: false),
                        EncabezadoOpClave = c.Int(nullable: false),
                        EncabezadoOpDesc = c.String(maxLength: 250),
                        EncabezadoClavDocClave = c.String(maxLength: 6),
                        EncabezadoClavDocDescripcion = c.String(maxLength: 250),
                        EncabezadoDestinoClave = c.Int(nullable: false),
                        EncabezadoDestionDesc = c.String(maxLength: 250),
                        EncabezadoAduEntSalidaClave = c.Int(nullable: false),
                        EncabezadoAduEntSalidaDesc = c.String(maxLength: 250),
                        EncabezadoTipoCambio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EncabezadoPesoBruto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EncabezadoMedTranspSalClave = c.Int(nullable: false),
                        EncabezadoMedTranspSalDesc = c.String(maxLength: 250),
                        EncabezadoMedTranspArriboClave = c.Int(nullable: false),
                        EncabezadoMedTranspArriboDesc = c.String(maxLength: 250),
                        EncabezadoMedTranspEntradaClave = c.Int(nullable: false),
                        EncabezadoMedTranspEntradaDesc = c.String(maxLength: 250),
                        CurpApoderadoMandatario = c.String(maxLength: 18),
                        RFCAduanalSocFactura = c.String(maxLength: 13),
                        ValorAduanaTotalDolares = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorAduanaTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorComercialTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpRfcImpExp = c.String(),
                        ImpExpCurpImpExp = c.String(),
                        ImpExpRazSocImpExp = c.String(maxLength: 120),
                        ImpExpDomCalle = c.String(maxLength: 80),
                        ImpExpNumDomExterior = c.String(maxLength: 10),
                        ImpExpNumDomInterior = c.String(maxLength: 10),
                        ImpExpDomCdMunicipio = c.String(maxLength: 80),
                        ImpExpDomCP = c.String(maxLength: 10),
                        ImpExpSeguros = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpFletes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpEmbalajes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpIncrementables = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpAudoDespachoClave = c.Int(nullable: false),
                        ImpExpAudoDespachoDesc = c.String(maxLength: 250),
                        ImpExpEfectivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpOtros = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImpExpPaisClave = c.String(maxLength: 3),
                        ImpExpPaisDesc = c.String(maxLength: 250),
                        DatosProvCompIdFiscalProvComprador = c.String(),
                        DatosProvCompProveedorComprador = c.String(),
                        DatosProvCompValorMonedaExt = c.String(),
                        DatosProvCompValorDolares = c.String(),
                        DatosProvCompDomCalle = c.String(),
                        DatosProvCompDomNumExterior = c.String(),
                        DatosProvCompDomNumInterior = c.String(),
                        DatosProvCompDomCdMunicipio = c.String(),
                        DatosProvCompDomCP = c.String(),
                        DatosProvCompPaisClave = c.String(),
                        DatosProvCompPaisDesc = c.String(),
                        DatosProvCompMonedaClave = c.String(),
                        DatosProvCompMonedaDesc = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DsPedimentoIdentificador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificadorComplemento1 = c.String(maxLength: 20),
                        IdentificadorComplemento2 = c.String(maxLength: 30),
                        IdentificadorComplemento3 = c.String(maxLength: 40),
                        ClaveIdentificadorClave = c.String(maxLength: 2),
                        ClaveIdentificadorDesc = c.String(maxLength: 250),
                        FechaCreacion = c.DateTime(nullable: false),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoImpExpFechas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImpExpFechasFecha = c.DateTime(nullable: false),
                        ImpExpFechasFechaEntradaTipoClave = c.Int(nullable: false),
                        ImpExpFechasFechaTipoDesc = c.String(maxLength: 250),
                        FechaCreacion = c.DateTime(nullable: false),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoTasa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TasasTasaAplicable = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TasasImporte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TasasClaveContribucionClave = c.Int(nullable: false),
                        TasasClaveContribucionDesc = c.String(maxLength: 250),
                        TasasTipoTasaClave = c.Int(nullable: false),
                        TasasTipoTasaDesc = c.String(maxLength: 250),
                        TasasFormaPagoClave = c.Int(nullable: false),
                        TasasFormaPagoDesc = c.String(maxLength: 250),
                        FechaCreacion = c.DateTime(nullable: false),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DsPedimentoTasa", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoImpExpFechas", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPartida", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoIdentificador", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPartidaIdentificador", "PartidaId", "dbo.DsPartida");
            DropForeignKey("dbo.DsPartidaTasa", "PartidaGravamenId", "dbo.DsPartidaGravamen");
            DropForeignKey("dbo.DsPartidaImporte", "PartidaGravamenId", "dbo.DsPartidaGravamen");
            DropForeignKey("dbo.DsPartidaGravamen", "PartidaId", "dbo.DsPartida");
            DropForeignKey("dbo.DsPedimentosLista", "ListaPedimentoId", "dbo.DsListaPedimento");
            DropIndex("dbo.DsPedimentoTasa", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoImpExpFechas", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoIdentificador", new[] { "PedimentoId" });
            DropIndex("dbo.DsPartidaTasa", new[] { "PartidaGravamenId" });
            DropIndex("dbo.DsPartidaImporte", new[] { "PartidaGravamenId" });
            DropIndex("dbo.DsPartidaGravamen", new[] { "PartidaId" });
            DropIndex("dbo.DsPartida", new[] { "PedimentoId" });
            DropIndex("dbo.DsPartidaIdentificador", new[] { "PartidaId" });
            DropIndex("dbo.DsPedimentosLista", new[] { "ListaPedimentoId" });
            DropTable("dbo.DsPedimentoTasa");
            DropTable("dbo.DsPedimentoImpExpFechas");
            DropTable("dbo.DsPedimentoIdentificador");
            DropTable("dbo.DsPedimento");
            DropTable("dbo.DsPartidaTasa");
            DropTable("dbo.DsPartidaImporte");
            DropTable("dbo.DsPartidaGravamen");
            DropTable("dbo.DsPartida");
            DropTable("dbo.DsPartidaIdentificador");
            DropTable("dbo.DsPedimentosLista");
            DropTable("dbo.DsListaPedimento");
        }
    }
}
