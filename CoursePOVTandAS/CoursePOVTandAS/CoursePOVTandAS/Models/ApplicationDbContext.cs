using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CoursePOVTandAS.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AcademicPlan> AcademicPlans { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<FixedTheme> FixedThemes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<GradualProgress> ListGradualProgress { get; set; }
        public DbSet<ScheduleOfWork> ScheduleOfWorks { get; set; }
        public DbSet<SessionResult> SessionResults { get; set; }

        public ApplicationDbContext()
            : base("CourseContext", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}