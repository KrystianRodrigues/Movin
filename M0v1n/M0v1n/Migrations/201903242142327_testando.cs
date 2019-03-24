namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testando : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Email = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Locador",
                c => new
                    {
                        LocadorID = c.Int(nullable: false, identity: true),
                        NomeLocador = c.String(unicode: false),
                        DataNascimentoLocador = c.String(unicode: false),
                        CpfLocador = c.String(unicode: false),
                        EmailLocador = c.String(unicode: false),
                        SenhaLocador = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.LocadorID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(unicode: false),
                        DataNascimentoUsuario = c.String(unicode: false),
                        CpfUsuario = c.String(unicode: false),
                        EmailUsuario = c.String(unicode: false),
                        SenhaUsuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Locador");
            DropTable("dbo.Cliente");
        }
    }
}
