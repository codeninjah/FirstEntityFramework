namespace Fotboll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class förstauppladdningen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arenas",
                c => new
                    {
                        ArenaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ArenaId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        ArenasId = c.Int(nullable: false),
                        Name = c.String(),
                        Arena_ArenaId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Arenas", t => t.Arena_ArenaId)
                .Index(t => t.Arena_ArenaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Arena_ArenaId", "dbo.Arenas");
            DropIndex("dbo.Teams", new[] { "Arena_ArenaId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Arenas");
        }
    }
}
