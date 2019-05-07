namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aval : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        AdministradorID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.AdministradorID);
            
            CreateTable(
                "dbo.Anuncio",
                c => new
                    {
                        AnuncioID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(unicode: false),
                        QuartoSolteiro = c.Int(nullable: false),
                        QuartoCasal = c.Int(nullable: false),
                        QuartoComunitario = c.Int(nullable: false),
                        QtdCama = c.Int(nullable: false),
                        QtdBanheiro = c.Int(nullable: false),
                        NumHospedes = c.Int(nullable: false),
                        ValorDiaria = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rua = c.String(unicode: false),
                        Bairro = c.String(unicode: false),
                        Complemento = c.String(unicode: false),
                        Numero = c.String(unicode: false),
                        Cidade = c.String(unicode: false),
                        UF = c.String(unicode: false),
                        Cep = c.String(unicode: false),
                        Foto1 = c.String(unicode: false),
                        Foto2 = c.String(unicode: false),
                        ArCondicionado = c.Boolean(nullable: false),
                        Ventilador = c.Boolean(nullable: false),
                        Banheira = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        TvCabo = c.Boolean(nullable: false),
                        Animais = c.Boolean(nullable: false),
                        Fumante = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        Problemas = c.String(unicode: false),
                        LocadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnuncioID)
                .ForeignKey("dbo.Locador", t => t.LocadorID, cascadeDelete: true)
                .Index(t => t.LocadorID);
            
            CreateTable(
                "dbo.Avaliar",
                c => new
                    {
                        AvaliarID = c.Int(nullable: false, identity: true),
                        From = c.String(unicode: false),
                        To = c.String(nullable: false, unicode: false),
                        Subject = c.String(unicode: false),
                        Body = c.String(nullable: false, unicode: false),
                        AnuncioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvaliarID)
                .ForeignKey("dbo.Anuncio", t => t.AnuncioID, cascadeDelete: true)
                .Index(t => t.AnuncioID);
            
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
            DropForeignKey("dbo.Anuncio", "LocadorID", "dbo.Locador");
            DropForeignKey("dbo.Avaliar", "AnuncioID", "dbo.Anuncio");
            DropIndex("dbo.Avaliar", new[] { "AnuncioID" });
            DropIndex("dbo.Anuncio", new[] { "LocadorID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Cancelar");
            DropTable("dbo.Locador");
            DropTable("dbo.Avaliar");
            DropTable("dbo.Anuncio");
            DropTable("dbo.Administrador");
        }
    }
}
