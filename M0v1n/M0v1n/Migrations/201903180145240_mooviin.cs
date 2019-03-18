namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mooviin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locador",
                c => new
                    {
                        LocadorID = c.Int(nullable: false, identity: true),
                        nomeLocador = c.String(unicode: false),
                        dataNascimentoLocador = c.String(unicode: false),
                        cpfLocador = c.String(unicode: false),
                        emailLocador = c.String(unicode: false),
                        senhaLocador = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.LocadorID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        nomeUsuario = c.String(unicode: false),
                        dataNascimentoUsuario = c.String(unicode: false),
                        cpfUsuario = c.String(unicode: false),
                        emailUsuario = c.String(unicode: false),
                        senhaUsuario = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Locador");
        }
    }
}
