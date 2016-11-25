using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class CourseContext:DbContext
    {
        public CourseContext() : base("CourseContext")
        {
        }

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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}