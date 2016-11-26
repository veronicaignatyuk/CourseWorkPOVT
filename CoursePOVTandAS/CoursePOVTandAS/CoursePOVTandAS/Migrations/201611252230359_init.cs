namespace CoursePOVTandAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicPlans",
                c => new
                    {
                        AcademicPlanId = c.Int(nullable: false, identity: true),
                        CodeOfDepartment = c.String(),
                        ItemName = c.String(),
                        SpecialityId = c.Int(nullable: false),
                        YearOfSet = c.Int(),
                        Semester = c.Int(),
                        StatementForm = c.String(),
                    })
                .PrimaryKey(t => t.AcademicPlanId)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.ScheduleOfWorks",
                c => new
                    {
                        ScheduleOfWorkId = c.Int(nullable: false, identity: true),
                        AcademicPlanId = c.Int(nullable: false),
                        StageName = c.String(),
                        ProjectedDate = c.DateTime(nullable: false),
                        PlannedPercent = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleOfWorkId)
                .ForeignKey("dbo.AcademicPlans", t => t.AcademicPlanId)
                .Index(t => t.AcademicPlanId);
            
            CreateTable(
                "dbo.GradualProgresses",
                c => new
                    {
                        GradualProgressId = c.Int(nullable: false, identity: true),
                        ScheduleOfWorkId = c.Int(nullable: false),
                        FixedThemeId = c.Int(nullable: false),
                        ActualPercent = c.Int(nullable: false),
                        CompletionDate = c.DateTime(nullable: false),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradualProgressId)
                .ForeignKey("dbo.FixedThemes", t => t.FixedThemeId)
                .ForeignKey("dbo.ScheduleOfWorks", t => t.ScheduleOfWorkId)
                .Index(t => t.ScheduleOfWorkId)
                .Index(t => t.FixedThemeId);
            
            CreateTable(
                "dbo.FixedThemes",
                c => new
                    {
                        FixedThemeId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ThemeId = c.Int(nullable: false),
                        DateOfIssue = c.DateTime(nullable: false),
                        CompletionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FixedThemeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Themes", t => t.ThemeId)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.ThemeId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        MiddleName = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupNumber = c.Int(nullable: false),
                        SpecialityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        SpecialityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CodeOfSpecialty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialityId);
            
            CreateTable(
                "dbo.SessionResults",
                c => new
                    {
                        SessionResultId = c.Int(nullable: false, identity: true),
                        AcademicPlanId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionResultId)
                .ForeignKey("dbo.AcademicPlans", t => t.AcademicPlanId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.AcademicPlanId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        MiddleName = c.String(),
                        Position = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        ThemeId = c.Int(nullable: false, identity: true),
                        TopicTitle = c.String(),
                        AcademicPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThemeId)
                .ForeignKey("dbo.AcademicPlans", t => t.AcademicPlanId)
                .Index(t => t.AcademicPlanId);
            
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
                "dbo.TeacherAcademicPlans",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        AcademicPlan_AcademicPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.AcademicPlan_AcademicPlanId })
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.AcademicPlans", t => t.AcademicPlan_AcademicPlanId, cascadeDelete: true)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.AcademicPlan_AcademicPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GradualProgresses", "ScheduleOfWorkId", "dbo.ScheduleOfWorks");
            DropForeignKey("dbo.FixedThemes", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Themes", "AcademicPlanId", "dbo.AcademicPlans");
            DropForeignKey("dbo.SessionResults", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.FixedThemes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeacherAcademicPlans", "AcademicPlan_AcademicPlanId", "dbo.AcademicPlans");
            DropForeignKey("dbo.TeacherAcademicPlans", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SessionResults", "StudentId", "dbo.Students");
            DropForeignKey("dbo.SessionResults", "AcademicPlanId", "dbo.AcademicPlans");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.AcademicPlans", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.FixedThemes", "StudentId", "dbo.Students");
            DropForeignKey("dbo.GradualProgresses", "FixedThemeId", "dbo.FixedThemes");
            DropForeignKey("dbo.ScheduleOfWorks", "AcademicPlanId", "dbo.AcademicPlans");
            DropIndex("dbo.TeacherAcademicPlans", new[] { "AcademicPlan_AcademicPlanId" });
            DropIndex("dbo.TeacherAcademicPlans", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Themes", new[] { "AcademicPlanId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.SessionResults", new[] { "TeacherId" });
            DropIndex("dbo.SessionResults", new[] { "StudentId" });
            DropIndex("dbo.SessionResults", new[] { "AcademicPlanId" });
            DropIndex("dbo.Groups", new[] { "SpecialityId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.FixedThemes", new[] { "ThemeId" });
            DropIndex("dbo.FixedThemes", new[] { "StudentId" });
            DropIndex("dbo.FixedThemes", new[] { "TeacherId" });
            DropIndex("dbo.GradualProgresses", new[] { "FixedThemeId" });
            DropIndex("dbo.GradualProgresses", new[] { "ScheduleOfWorkId" });
            DropIndex("dbo.ScheduleOfWorks", new[] { "AcademicPlanId" });
            DropIndex("dbo.AcademicPlans", new[] { "SpecialityId" });
            DropTable("dbo.TeacherAcademicPlans");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Themes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Teachers");
            DropTable("dbo.SessionResults");
            DropTable("dbo.Specialities");
            DropTable("dbo.Groups");
            DropTable("dbo.Students");
            DropTable("dbo.FixedThemes");
            DropTable("dbo.GradualProgresses");
            DropTable("dbo.ScheduleOfWorks");
            DropTable("dbo.AcademicPlans");
        }
    }
}
