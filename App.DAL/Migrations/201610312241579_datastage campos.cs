namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datastagecampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsDataStage", "NombreArchivo", c => c.String());
            AddColumn("dbo.DsDataStage", "NombreCreador", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsDataStage", "NombreCreador");
            DropColumn("dbo.DsDataStage", "NombreArchivo");
        }
    }
}
