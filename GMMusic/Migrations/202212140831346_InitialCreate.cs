namespace GMMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                        SourcePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackPlaylists",
                c => new
                    {
                        Track_Id = c.Int(nullable: false),
                        Playlist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Track_Id, t.Playlist_Id })
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .ForeignKey("dbo.Playlists", t => t.Playlist_Id, cascadeDelete: true)
                .Index(t => t.Track_Id)
                .Index(t => t.Playlist_Id);
            
            CreateTable(
                "dbo.TagTracks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Track_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Track_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagTracks", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.TagTracks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TrackPlaylists", "Playlist_Id", "dbo.Playlists");
            DropForeignKey("dbo.TrackPlaylists", "Track_Id", "dbo.Tracks");
            DropIndex("dbo.TagTracks", new[] { "Track_Id" });
            DropIndex("dbo.TagTracks", new[] { "Tag_Id" });
            DropIndex("dbo.TrackPlaylists", new[] { "Playlist_Id" });
            DropIndex("dbo.TrackPlaylists", new[] { "Track_Id" });
            DropTable("dbo.TagTracks");
            DropTable("dbo.TrackPlaylists");
            DropTable("dbo.Tags");
            DropTable("dbo.Tracks");
            DropTable("dbo.Playlists");
        }
    }
}
