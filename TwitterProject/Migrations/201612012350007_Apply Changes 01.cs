namespace TwitterProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyChanges01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        texto = c.String(),
                        PostID = c.String(),
                        Posts_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.Posts_ID)
                .Index(t => t.Posts_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 200),
                        dataPost = c.DateTime(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.PostHashtags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        HashtagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Hashtags", t => t.HashtagID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.HashtagID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.VinculoUsuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ativo = c.Boolean(nullable: false),
                        User1ID = c.String(maxLength: 128),
                        User2ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User1ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User2ID)
                .Index(t => t.User1ID)
                .Index(t => t.User2ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VinculoUsuarios", "User2ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.VinculoUsuarios", "User1ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostHashtags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostHashtags", "HashtagID", "dbo.Hashtags");
            DropForeignKey("dbo.Hashtags", "Posts_ID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.VinculoUsuarios", new[] { "User2ID" });
            DropIndex("dbo.VinculoUsuarios", new[] { "User1ID" });
            DropIndex("dbo.PostHashtags", new[] { "PostID" });
            DropIndex("dbo.PostHashtags", new[] { "HashtagID" });
            DropIndex("dbo.Hashtags", new[] { "Posts_ID" });
            DropIndex("dbo.Posts", new[] { "ApplicationUserID" });
            DropTable("dbo.VinculoUsuarios");
            DropTable("dbo.PostHashtags");
            DropTable("dbo.Posts");
            DropTable("dbo.Hashtags");
        }
    }
}
