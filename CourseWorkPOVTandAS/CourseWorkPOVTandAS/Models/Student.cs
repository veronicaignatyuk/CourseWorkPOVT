using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<FixedTheme> FixedThemes { get; set; }
        public virtual ICollection<SessionResult> SessionResults { get; set; }
        public Student()
        {
            FixedThemes = new HashSet<FixedTheme>();
            SessionResults = new HashSet<SessionResult>();
        }

    }
}