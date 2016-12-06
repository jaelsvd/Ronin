namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patenteyaduanaenlistapedimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsListaPedimento", "Patente", c => c.Int(nullable: false));
            AddColumn("dbo.DsListaPedimento", "Aduana", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsListaPedimento", "Aduana");
            DropColumn("dbo.DsListaPedimento", "Patente");
        }
    }
}
