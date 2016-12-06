namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class difcontribucion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PedimentoDiferenciaContribucion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportePago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClaveGravamen1Clave = c.Int(nullable: false),
                        ClaveGravamen1Desc = c.String(),
                        FormaPagoClave = c.Int(nullable: false),
                        FormaPagoDesc = c.String(),
                        PedimentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPedimento", t => t.PedimentoId, cascadeDelete: true)
                .Index(t => t.PedimentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedimentoDiferenciaContribucion", "PedimentoId", "dbo.DsPedimento");
            DropIndex("dbo.PedimentoDiferenciaContribucion", new[] { "PedimentoId" });
            DropTable("dbo.PedimentoDiferenciaContribucion");
        }
    }
}
