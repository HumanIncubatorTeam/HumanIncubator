namespace PhotoAlbum.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addguidprimarykey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatedOn = c.DateTime(nullable: false),
                        StatusId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageDescriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.Binary(nullable: false, maxLength: 256),
                        ImageId = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        StatusId = c.Guid(nullable: false),
                        NameWithExtension = c.String(nullable: false, maxLength: 100, unicode: false),
                        UniqueName = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statuses", t => t.StatusId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        StatusId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        PasswordHash = c.String(nullable: false, unicode: false),
                        PasswordSalt = c.String(nullable: false, unicode: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        Email = c.String(name: "E-mail", nullable: false, maxLength: 50, unicode: false),
                        Skype = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statuses", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ImagesDescriptionsHashtags",
                c => new
                    {
                        IdHashtag = c.Guid(nullable: false),
                        IdDescription = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdHashtag, t.IdDescription })
                .ForeignKey("dbo.Hashtags", t => t.IdHashtag, cascadeDelete: true)
                .ForeignKey("dbo.ImageDescriptions", t => t.IdDescription, cascadeDelete: true)
                .Index(t => t.IdHashtag)
                .Index(t => t.IdDescription);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagesDescriptionsHashtags", "IdDescription", "dbo.ImageDescriptions");
            DropForeignKey("dbo.ImagesDescriptionsHashtags", "IdHashtag", "dbo.Hashtags");
            DropForeignKey("dbo.Users", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.UsersRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropForeignKey("dbo.Images", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.ImageDescriptions", "ImageId", "dbo.Images");
            DropIndex("dbo.ImagesDescriptionsHashtags", new[] { "IdDescription" });
            DropIndex("dbo.ImagesDescriptionsHashtags", new[] { "IdHashtag" });
            DropIndex("dbo.UsersRoles", new[] { "UserId" });
            DropIndex("dbo.UsersRoles", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "StatusId" });
            DropIndex("dbo.Images", new[] { "StatusId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.ImageDescriptions", new[] { "ImageId" });
            DropTable("dbo.ImagesDescriptionsHashtags");
            DropTable("dbo.UsersRoles");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Statuses");
            DropTable("dbo.Images");
            DropTable("dbo.ImageDescriptions");
            DropTable("dbo.Hashtags");
        }
    }
}
