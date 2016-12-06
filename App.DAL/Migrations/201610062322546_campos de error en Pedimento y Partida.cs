namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposdeerrorenPedimentoyPartida : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPartida", "Tiempo", c => c.String());
            AddColumn("dbo.DsPartida", "ErrorDesc", c => c.String());
            AddColumn("dbo.DsPedimento", "Tiempo", c => c.String());
            AddColumn("dbo.DsPedimento", "ErrorDesc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsPedimento", "ErrorDesc");
            DropColumn("dbo.DsPedimento", "Tiempo");
            DropColumn("dbo.DsPartida", "ErrorDesc");
            DropColumn("dbo.DsPartida", "Tiempo");
        }
    }
}
