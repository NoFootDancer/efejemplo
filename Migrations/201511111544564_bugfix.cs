namespace WpfApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleados", "DepartamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleados", "DepartamentoId");
            AddForeignKey("dbo.Empleados", "DepartamentoId", "dbo.Departamentoes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "DepartamentoId", "dbo.Departamentoes");
            DropIndex("dbo.Empleados", new[] { "DepartamentoId" });
            DropColumn("dbo.Empleados", "DepartamentoId");
        }
    }
}
