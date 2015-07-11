namespace JML.SteelIce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.Int(nullable: false),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        StateProvinceCounty = c.String(),
                        Country = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Job_Id = c.Guid(),
                        Project_Id = c.Guid(),
                        UserAccount_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        Deadline = c.DateTime(),
                        EstimatedValue = c.Double(nullable: false),
                        Project_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        Deadline = c.DateTime(),
                        EstimatedValue = c.Double(nullable: false),
                        UserAccount_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsEmployee = c.Boolean(nullable: false),
                        NotifyMeAboutActivity = c.Boolean(nullable: false),
                        Photo = c.Binary(),
                        CompanyName = c.String(),
                        CompanyType = c.Int(nullable: false),
                        Established = c.DateTime(),
                        EstablishedBy = c.String(),
                        ManageEmployees = c.Boolean(nullable: false),
                        ManageProjects = c.Boolean(nullable: false),
                        ManageCompany = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ErrorLists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExceptionMessage = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        RepeatingAt = c.DateTime(),
                        ExceptionMessage = c.String(),
                        UserAccount = c.String(),
                        RepeatLog = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Inviter = c.Guid(nullable: false),
                        InvitationStatus = c.Int(nullable: false),
                        Invitee = c.String(nullable: false),
                        Message = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModified = c.DateTime(),
                        InvitionToJob = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobContributors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        Job_Id = c.Guid(),
                        UserAccount_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.JobPermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Permissions = c.Int(nullable: false),
                        Job_Id = c.Guid(),
                        UserAccount_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.JobTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Assignee = c.Guid(nullable: false),
                        StartDate = c.DateTime(),
                        Deadline = c.DateTime(),
                        ShowProgressToAssignee = c.Boolean(nullable: false),
                        LogTrack = c.String(),
                        Progress = c.Double(nullable: false),
                        Job_Id = c.Guid(),
                        UserAccount_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.ProjectRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Role = c.Int(nullable: false),
                        Project_Id = c.Guid(),
                        UserAccount_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.RFIs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Addressee = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        StatusChangeBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Deadline = c.DateTime(),
                        Job_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .Index(t => t.Job_Id);
            
            CreateTable(
                "dbo.RFIAnswers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnsweredBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Message = c.String(),
                        Rfi_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RFIs", t => t.Rfi_Id)
                .Index(t => t.Rfi_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RFIAnswers", "Rfi_Id", "dbo.RFIs");
            DropForeignKey("dbo.RFIs", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.ProjectRoles", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.ProjectRoles", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.JobTasks", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.JobTasks", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.JobPermissions", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.JobPermissions", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.JobContributors", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.JobContributors", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Addresses", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.Addresses", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Addresses", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "UserAccount_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RFIAnswers", new[] { "Rfi_Id" });
            DropIndex("dbo.RFIs", new[] { "Job_Id" });
            DropIndex("dbo.ProjectRoles", new[] { "UserAccount_Id" });
            DropIndex("dbo.ProjectRoles", new[] { "Project_Id" });
            DropIndex("dbo.JobTasks", new[] { "UserAccount_Id" });
            DropIndex("dbo.JobTasks", new[] { "Job_Id" });
            DropIndex("dbo.JobPermissions", new[] { "UserAccount_Id" });
            DropIndex("dbo.JobPermissions", new[] { "Job_Id" });
            DropIndex("dbo.JobContributors", new[] { "UserAccount_Id" });
            DropIndex("dbo.JobContributors", new[] { "Job_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserAccounts", new[] { "User_Id" });
            DropIndex("dbo.Projects", new[] { "UserAccount_Id" });
            DropIndex("dbo.Jobs", new[] { "Project_Id" });
            DropIndex("dbo.Addresses", new[] { "UserAccount_Id" });
            DropIndex("dbo.Addresses", new[] { "Project_Id" });
            DropIndex("dbo.Addresses", new[] { "Job_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RFIAnswers");
            DropTable("dbo.RFIs");
            DropTable("dbo.ProjectRoles");
            DropTable("dbo.JobTasks");
            DropTable("dbo.JobPermissions");
            DropTable("dbo.JobContributors");
            DropTable("dbo.Invitations");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.ErrorLogs");
            DropTable("dbo.ErrorLists");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Projects");
            DropTable("dbo.Jobs");
            DropTable("dbo.Addresses");
        }
    }
}
