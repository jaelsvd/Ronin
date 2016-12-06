namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vinculacion1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DsPartidaMetodoValoracion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MetodoValorDesc = c.String(),
                        MetodoValorClave = c.Int(nullable: false),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.DsPartidaVinculacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VinculacionDesc = c.String(),
                        VinculacionClave = c.Int(nullable: false),
                        PartidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DsPartida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId);
            
            DropColumn("dbo.DsPartida", "MetodoValorDesc");
            DropColumn("dbo.DsPartida", "MetodoValorClave");
            DropColumn("dbo.DsPartida", "VinculacionDesc");
            DropColumn("dbo.DsPartida", "VinculacionClave");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DsPartida", "VinculacionClave", c => c.Int(nullable: false));
            AddColumn("dbo.DsPartida", "VinculacionDesc", c => c.String());
            AddColumn("dbo.DsPartida", "MetodoValorClave", c => c.Int(nullable: false));
            AddColumn("dbo.DsPartida", "MetodoValorDesc", c => c.String());
            DropForeignKey("dbo.DsPartidaVinculacion", "PartidaId", "dbo.DsPartida");
            DropForeignKey("dbo.DsPartidaMetodoValoracion", "PartidaId", "dbo.DsPartida");
            DropIndex("dbo.DsPartidaVinculacion", new[] { "PartidaId" });
            DropIndex("dbo.DsPartidaMetodoValoracion", new[] { "PartidaId" });
            DropTable("dbo.DsPartidaVinculacion");
            DropTable("dbo.DsPartidaMetodoValoracion");
        }
    }
}
