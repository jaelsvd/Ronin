namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entidadValVin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPartida", "MetodoValorClave", c => c.Int(nullable: false));
            AddColumn("dbo.DsPartida", "VinculacionClave", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsPartida", "VinculacionClave");
            DropColumn("dbo.DsPartida", "MetodoValorClave");
        }
    }
}
