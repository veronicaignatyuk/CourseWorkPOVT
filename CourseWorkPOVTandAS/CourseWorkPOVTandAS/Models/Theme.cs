using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string TopicTitle { get; set; }
        public int AcademicPlanId { get; set; }
        public virtual AcademicPlan AcademicPlan { get; set; }

        public virtual ICollection<FixedTheme> FixedThemes { get; set; }
        public Theme()
        {
            FixedThemes = new HashSet<FixedTheme>();
        }
    }
}