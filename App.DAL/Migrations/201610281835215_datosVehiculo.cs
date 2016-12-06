namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datosVehiculo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DsPartidaDatosVehiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VinNumeroSerie = c.String(),
                        Kilometraje = c.Long(nullable: false),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DsPartidaDatosVehiculo", "PartidaId", "dbo.DsPartida");
            DropIndex("dbo.DsPartidaDatosVehiculo", new[] { "PartidaId" });
            DropTable("dbo.DsPartidaDatosVehiculo");
        }
    }
}
