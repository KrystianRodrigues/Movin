namespace M0v1n.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aval : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Avaliar");
        }
    }
}
