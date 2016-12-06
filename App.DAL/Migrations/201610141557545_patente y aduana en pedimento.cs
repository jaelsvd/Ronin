namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patenteyaduanaenpedimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPedimento", "Patente", c => c.Int(nullable: false));
            AddColumn("dbo.DsPedimento", "Aduana", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DsPedimento", "Aduana");
            DropColumn("dbo.DsPedimento", "Patente");
        }
    }
}
