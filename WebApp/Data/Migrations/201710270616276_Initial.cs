namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        UserDetailsDTO_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.UserDetailsDTOes", t => t.UserDetailsDTO_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.UserDetailsDTO_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserDetailsDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Age = c.Int(nullable: false),
                        UserRoleName = c.String(),
                        DepartmentName = c.String(),
                        UserRoleId = c.Int(nullable: false),
                        FileType = c.String(),
                        FilePath_FilePathId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FilePaths", t => t.FilePath_FilePathId)
                .Index(t => t.FilePath_FilePathId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsersRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Age = c.Int(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                        FilePath_FilePathId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FilePaths", t => t.FilePath_FilePathId)
                .ForeignKey("dbo.UsersRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.FilePath_FilePathId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UsersRoles");
            DropForeignKey("dbo.Files", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "FilePath_FilePathId", "dbo.FilePaths");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Files", "UserDetailsDTO_Id", "dbo.UserDetailsDTOes");
            DropForeignKey("dbo.UserDetailsDTOes", "FilePath_FilePathId", "dbo.FilePaths");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Users", new[] { "FilePath_FilePathId" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserDetailsDTOes", new[] { "FilePath_FilePathId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Files", new[] { "User_Id" });
            DropIndex("dbo.Files", new[] { "UserDetailsDTO_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UsersRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserDetailsDTOes");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Files");
            DropTable("dbo.FilePaths");
        }
    }
}
