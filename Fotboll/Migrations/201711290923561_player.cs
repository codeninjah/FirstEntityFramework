namespace Fotboll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class player : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "Arena_ArenaId", "dbo.Arenas");
            DropIndex("dbo.Teams", new[] { "Arena_ArenaId" });
            RenameColumn(table: "dbo.Teams", name: "Arena_ArenaId", newName: "ArenaId");
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            AlterColumn("dbo.Teams", "ArenaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "ArenaId");
            AddForeignKey("dbo.Teams", "ArenaId", "dbo.Arenas", "ArenaId", cascadeDelete: true);
            DropColumn("dbo.Teams", "ArenasId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "ArenasId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Teams", "ArenaId", "dbo.Arenas");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "ArenaId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            AlterColumn("dbo.Teams", "ArenaId", c => c.Int());
            DropTable("dbo.Players");
            RenameColumn(table: "dbo.Teams", name: "ArenaId", newName: "Arena_ArenaId");
            CreateIndex("dbo.Teams", "Arena_ArenaId");
            AddForeignKey("dbo.Teams", "Arena_ArenaId", "dbo.Arenas", "ArenaId");
        }
    }
}
