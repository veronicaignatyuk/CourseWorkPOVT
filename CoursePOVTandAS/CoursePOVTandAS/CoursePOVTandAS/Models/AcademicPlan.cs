using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePOVTandAS.Models
{
    public class AcademicPlan
    {
        public int AcademicPlanId { get; set; }
        public string CodeOfDepartment { get; set; }
        public string ItemName { get; set; }
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }
        public int? YearOfSet { get; set; }
        public int? Semester { get; set; }
        public string StatementForm { get; set; }

        public virtual ICollection<ScheduleOfWork> ScheduleOfWork { get; set; }
        public virtual ICollection<SessionResult> SessionResults { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }

        public AcademicPlan()
        {
            ScheduleOfWork = new HashSet<ScheduleOfWork>();
            SessionResults = new HashSet<SessionResult>();
            Themes = new HashSet<Theme>();
            Teachers = new HashSet<Teacher>();
        }

    }
}