namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paisenProvedorComprador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompPais", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsPedimentoProveedorComprador", "DatosProvCompPais");
        }
    }
}
