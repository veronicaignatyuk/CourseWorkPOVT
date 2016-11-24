using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class SessionResult
    {
        public int Id { get; set; }
        public int AcademicPlanId { get; set; }
        public virtual AcademicPlan AcademicPlan { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
    }
}