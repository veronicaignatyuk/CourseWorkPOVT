using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FixedTheme> FixedThemes { get; set; }
        public virtual ICollection<SessionResult> SessionResults { get; set; }
        public virtual ICollection<AcademicPlan> AcademicPlans { get; set; }
        public Teacher()
        {
            FixedThemes = new HashSet<FixedTheme>();
            SessionResults = new HashSet<SessionResult>();
            AcademicPlans = new HashSet<AcademicPlan>();
        }
    }
}