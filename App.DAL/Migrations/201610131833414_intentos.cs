namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intentos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsListaPedimento", "Intentos", c => c.Int(nullable: false));
            AddColumn("dbo.DsPedimento", "Intentos", c => c.Int(nullable: false));
            AddColumn("dbo.DsPartida", "Intentos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsPartida", "Intentos");
            DropColumn("dbo.DsPedimento", "Intentos");
            DropColumn("dbo.DsListaPedimento", "Intentos");
        }
    }
}
