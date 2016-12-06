namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agenteaduanal : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.AgentesAduanales",
            //    c => new
            //    {
            //        id = c.Int(nullable: false, identity: true),
            //        Nombre = c.String(nullable: false, maxLength: 255),
            //        RepLegal = c.String(nullable: false, maxLength: 255),
            //        Patente = c.String(nullable: false, maxLength: 4),
            //        TaxID = c.String(maxLength: 20),
            //        Broker = c.Boolean(nullable: false),
            //        CTPAT = c.Boolean(nullable: false),
            //        OEA = c.Boolean(nullable: false),
            //    })
            //    .PrimaryKey(t => t.id);

        }
        
        public override void Down()
        {
            //DropTable("dbo.AgentesAduanales");
        }
    }
}
