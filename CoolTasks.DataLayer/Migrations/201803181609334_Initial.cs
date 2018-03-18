namespace CoolTasks.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoolTaskPictures",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CoolTaskId = c.Guid(nullable: false),
                        Url = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoolTasks", t => t.CoolTaskId, cascadeDelete: true)
                .Index(t => t.CoolTaskId);
            
            CreateTable(
                "dbo.CoolTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Guid(),
                        GoalId = c.Guid(),
                        GroupId = c.Guid(),
                        TypeIconId = c.Guid(nullable: false),
                        CreatedByUserId = c.String(maxLength: 36),
                        Caption = c.String(maxLength: 256),
                        ContentsHtml = c.String(maxLength: 4000),
                        ResultsHtml = c.String(maxLength: 4000),
                        DeadlineUtc = c.DateTime(),
                        DoneAtUtc = c.DateTime(),
                        CreatedAtUtc = c.DateTime(nullable: false),
                        Order = c.Int(nullable: false),
                        IsOnHold = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUserId)
                .ForeignKey("dbo.Goals", t => t.GoalId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.CoolTasks", t => t.ParentId)
                .ForeignKey("dbo.TypeIcons", t => t.TypeIconId)
                .Index(t => t.ParentId)
                .Index(t => t.GoalId)
                .Index(t => t.GroupId)
                .Index(t => t.TypeIconId)
                .Index(t => t.CreatedByUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        PhotoUrl = c.String(maxLength: 256),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 36),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Caption = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 4000),
                        ProviderKey = c.String(nullable: false, maxLength: 4000),
                        UserId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 36),
                        RoleId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TypeIconId = c.Guid(nullable: false),
                        Caption = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeIcons", t => t.TypeIconId)
                .Index(t => t.TypeIconId);
            
            CreateTable(
                "dbo.TypeIcons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Url = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        Group_Id = c.Guid(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.User_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Group_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CoolTasks", "TypeIconId", "dbo.TypeIcons");
            DropForeignKey("dbo.CoolTaskPictures", "CoolTaskId", "dbo.CoolTasks");
            DropForeignKey("dbo.CoolTasks", "ParentId", "dbo.CoolTasks");
            DropForeignKey("dbo.CoolTasks", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.CoolTasks", "GoalId", "dbo.Goals");
            DropForeignKey("dbo.Goals", "TypeIconId", "dbo.TypeIcons");
            DropForeignKey("dbo.CoolTasks", "CreatedByUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupUsers", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.GroupUsers", new[] { "User_Id" });
            DropIndex("dbo.GroupUsers", new[] { "Group_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Goals", new[] { "TypeIconId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CoolTasks", new[] { "CreatedByUserId" });
            DropIndex("dbo.CoolTasks", new[] { "TypeIconId" });
            DropIndex("dbo.CoolTasks", new[] { "GroupId" });
            DropIndex("dbo.CoolTasks", new[] { "GoalId" });
            DropIndex("dbo.CoolTasks", new[] { "ParentId" });
            DropIndex("dbo.CoolTaskPictures", new[] { "CoolTaskId" });
            DropTable("dbo.GroupUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TypeIcons");
            DropTable("dbo.Goals");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Groups");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CoolTasks");
            DropTable("dbo.CoolTaskPictures");
        }
    }
}
