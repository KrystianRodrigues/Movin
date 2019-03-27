namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Anuncio : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anuncio");
        }
    }
}
