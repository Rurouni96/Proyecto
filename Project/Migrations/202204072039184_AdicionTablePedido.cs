namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablePedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        CLienteId = c.Int(nullable: false),
                        DescuentoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Cliente", t => t.CLienteId)
                .Index(t => t.CLienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "CLienteId", "dbo.Cliente");
            DropIndex("dbo.Pedido", new[] { "CLienteId" });
            DropTable("dbo.Pedido");
        }
    }
}
