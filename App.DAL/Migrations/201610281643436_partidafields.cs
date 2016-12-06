namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partidafields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPartida", "CodigoMercancia", c => c.String());
            AddColumn("dbo.DsPartida", "SubDivisionFraccion", c => c.String());
            AddColumn("dbo.DsPartida", "MarcaMercancia", c => c.String());
            AddColumn("dbo.DsPartida", "ModeloMercancia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsPartida", "ModeloMercancia");
            DropColumn("dbo.DsPartida", "MarcaMercancia");
            DropColumn("dbo.DsPartida", "SubDivisionFraccion");
            DropColumn("dbo.DsPartida", "CodigoMercancia");
        }
    }
}
