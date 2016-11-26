using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CoursePOVTandAS.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
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