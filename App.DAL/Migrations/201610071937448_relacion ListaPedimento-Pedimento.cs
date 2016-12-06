namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionListaPedimentoPedimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DsPedimento", "ListaPedimentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.DsPedimento", "ListaPedimentoId");
            AddForeignKey("dbo.DsPedimento", "ListaPedimentoId", "dbo.DsListaPedimento", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DsPedimento", "ListaPedimentoId", "dbo.DsListaPedimento");
            DropIndex("dbo.DsPedimento", new[] { "ListaPedimentoId" });
            DropColumn("dbo.DsPedimento", "ListaPedimentoId");
        }
    }
}
