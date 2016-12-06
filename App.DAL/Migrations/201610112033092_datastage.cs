namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datastage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DsDataStage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicial = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                        URLZip = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DsDataStage");
        }
    }
}
