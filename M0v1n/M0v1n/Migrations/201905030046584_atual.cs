namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atual : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anuncio",
                c => new
                    {
                        AnuncioID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        Unidade = c.String(unicode: false),
                        Genero = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.AnuncioID);
            
            CreateTable(
                "dbo.Avaliar",
                c => new
                    {
                        AvaliarID = c.Int(nullable: false, identity: true),
                        From = c.String(unicode: false),
                        To = c.String(nullable: false, unicode: false),
                        Subject = c.String(unicode: false),
                        Body = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.AvaliarID);
            
            CreateTable(
                "dbo.Cancelar",
                c => new
                    {
                        CancelarID = c.Int(nullable: false, identity: true),
                        From = c.String(unicode: false),
                        To = c.String(nullable: false, unicode: false),
                        Subject = c.String(nullable: false, unicode: false),
                        Body = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.CancelarID);
            
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
            DropTable("dbo.Cancelar");
            DropTable("dbo.Avaliar");
            DropTable("dbo.Anuncio");
        }
    }
}
