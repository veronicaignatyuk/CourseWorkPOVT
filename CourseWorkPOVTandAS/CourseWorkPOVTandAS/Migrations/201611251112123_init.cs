namespace CourseWorkPOVTandAS.Migrations
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GradualProgresses", "ScheduleOfWorkId", "dbo.ScheduleOfWorks");
            DropForeignKey("dbo.FixedThemes", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Themes", "AcademicPlanId", "dbo.AcademicPlans");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.SessionResults", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.FixedThemes", "TeacherId", "dbo.Teachers");
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
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleId" });
            DropIndex("dbo.TeacherAcademicPlans", new[] { "AcademicPlan_AcademicPlanId" });
            DropIndex("dbo.TeacherAcademicPlans", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Themes", new[] { "AcademicPlanId" });
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
            DropTable("dbo.RoleUsers");
            DropTable("dbo.TeacherAcademicPlans");
            DropTable("dbo.Themes");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
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
