namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DsPartidaCuentaAduanera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InsEmClave = c.Int(nullable: false),
                        InsEmDescripcion = c.String(),
                        NumCuenta = c.Int(nullable: false),
                        FolioConstancia = c.String(),
                        FechaConstancia = c.DateTime(nullable: false),
                        TipoCuentaDesc = c.String(),
                        TipoGarantia = c.String(),
                        GarantiaTotalGarantia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GarantiaCantidadUMC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.DsPartidaPermiso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermisoClave = c.String(),
                        PermisoDesc = c.String(),
                        NumeroPermiso = c.String(),
                        FirmaDescargo = c.String(),
                        ValorComercialEnDolar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CantidadUMTUMC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.DsPedimentoContenedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdContenedor = c.String(),
                        TipoContenerdorClave = c.Int(nullable: false),
                        TipoContenedorDesc = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoCuentaAduanera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstEmisoraClave = c.Int(nullable: false),
                        InstEmisoraDesc = c.String(),
                        InstEmisoraNumCuenta = c.String(),
                        InstEmisoraFolioConstancia = c.String(),
                        FechaConstancia = c.DateTime(nullable: false),
                        TipoCuentaDesc = c.String(),
                        TipoGarantiaDesc = c.String(),
                        CuentaTotalGarantia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaCantidadUMC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoDescargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatenteOriginal = c.Int(nullable: false),
                        PedimentoOriginal = c.Int(nullable: false),
                        AduanaOrigClave = c.Int(nullable: false),
                        AduanaOrigDesc = c.String(),
                        ClaveDocOrigClave = c.String(),
                        ClaveDocOrigDesc = c.String(),
                        FechaPagoOriginal = c.DateTime(nullable: false),
                        FraccionOriginal = c.String(),
                        UnidadMedOrigClave = c.String(),
                        UnidadMedOrigDesc = c.String(),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoDestinatario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdFiscal = c.String(),
                        NombreDestinatario = c.String(),
                        Calle = c.String(),
                        NumExt = c.String(),
                        NumInt = c.String(),
                        CdMunicipio = c.String(),
                        CP = c.String(),
                        EntidadFederativa = c.String(),
                        PaisClave = c.String(),
                        PaisDesc = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoFactura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaFacturacion = c.DateTime(nullable: false),
                        NumeroFactura = c.String(),
                        TerminoFacturacionClave = c.String(),
                        TerminoFacturacionDesc = c.String(),
                        MonedaClave = c.String(),
                        MonedaDesc = c.String(),
                        ValDolares = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValMonedaExt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdFiscalProvComp = c.String(),
                        ProveedorComp = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoGuia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuiaManifesto = c.String(),
                        TipoGuia = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            CreateTable(
                "dbo.DsPedimentoTransporte",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificadorTransporte = c.String(),
                        PaisTransporteClave = c.String(),
                        PaisTransporteDesc = c.String(),
                        NombreTransporte = c.String(),
                        RFCTransporte = c.String(),
                        CURPTransportista = c.String(),
                        DomFiscalTransportista = c.String(),
                        CandadosTransporte = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
            AddColumn("dbo.DsPedimento", "aduOrigRectificacionClav", c => c.Int(nullable: false));
            AddColumn("dbo.DsPedimento", "aduOrigRectificacionDesc", c => c.String());
            AddColumn("dbo.DsPedimento", "aduDespRectificacionClav", c => c.Int(nullable: false));
            AddColumn("dbo.DsPedimento", "aduDespRectificacionDesc", c => c.String());
            AddColumn("dbo.DsPedimento", "ClavDocRectificacionClave", c => c.String());
            AddColumn("dbo.DsPedimento", "ClavDocRectificacionDesc", c => c.String());
            AddColumn("dbo.DsPedimento", "FechaPagoRectificacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.DsPedimento", "PedimentoOriginalRectificacion", c => c.Int(nullable: false));
            AddColumn("dbo.DsPedimento", "PatenteOriginalRectificacion", c => c.Int(nullable: false));
            AddColumn("dbo.DsPedimento", "FechaOriginalRectificacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DsPedimentoTransporte", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoGuia", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoFactura", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoDestinatario", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoDescargo", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoCuentaAduanera", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPedimentoContenedor", "PedimentoId", "dbo.DsPedimento");
            DropForeignKey("dbo.DsPartidaPermiso", "PartidaId", "dbo.DsPartida");
            DropForeignKey("dbo.DsPartidaCuentaAduanera", "PartidaId", "dbo.DsPartida");
            DropIndex("dbo.DsPedimentoTransporte", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoGuia", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoFactura", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoDestinatario", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoDescargo", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoCuentaAduanera", new[] { "PedimentoId" });
            DropIndex("dbo.DsPedimentoContenedor", new[] { "PedimentoId" });
            DropIndex("dbo.DsPartidaPermiso", new[] { "PartidaId" });
            DropIndex("dbo.DsPartidaCuentaAduanera", new[] { "PartidaId" });
            DropColumn("dbo.DsPedimento", "FechaOriginalRectificacion");
            DropColumn("dbo.DsPedimento", "PatenteOriginalRectificacion");
            DropColumn("dbo.DsPedimento", "PedimentoOriginalRectificacion");
            DropColumn("dbo.DsPedimento", "FechaPagoRectificacion");
            DropColumn("dbo.DsPedimento", "ClavDocRectificacionDesc");
            DropColumn("dbo.DsPedimento", "ClavDocRectificacionClave");
            DropColumn("dbo.DsPedimento", "aduDespRectificacionDesc");
            DropColumn("dbo.DsPedimento", "aduDespRectificacionClav");
            DropColumn("dbo.DsPedimento", "aduOrigRectificacionDesc");
            DropColumn("dbo.DsPedimento", "aduOrigRectificacionClav");
            DropTable("dbo.DsPedimentoTransporte");
            DropTable("dbo.DsPedimentoGuia");
            DropTable("dbo.DsPedimentoFactura");
            DropTable("dbo.DsPedimentoDestinatario");
            DropTable("dbo.DsPedimentoDescargo");
            DropTable("dbo.DsPedimentoCuentaAduanera");
            DropTable("dbo.DsPedimentoContenedor");
            DropTable("dbo.DsPartidaPermiso");
            DropTable("dbo.DsPartidaCuentaAduanera");
        }
    }
}
