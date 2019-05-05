namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrador", "Nome", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Administrador", "Nome");
        }
    }
}
