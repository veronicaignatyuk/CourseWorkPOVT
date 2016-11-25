using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class FixedTheme
    {
        public int FixedThemeId { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime CompletionDate { get; set; }

        public virtual ICollection<GradualProgress> GradualProgress { get; set; }
        public FixedTheme()
        {
            GradualProgress = new HashSet<GradualProgress>();
        }
    }
}