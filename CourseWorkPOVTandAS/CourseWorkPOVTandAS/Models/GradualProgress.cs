using System;
using System.Collections.Generic;

namespace CourseWorkPOVTandAS.Models
{
    public partial class GradualProgress
    {
        public int GradualProgressId { get; set; }
        public int ScheduleOfWorkId { get; set; }
        public virtual ScheduleOfWork ScheduleOfWork { get; set; }
        public int FixedThemeId { get; set; }
        public virtual FixedTheme FixedTheme { get; set; }
        public int ActualPercent { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Mark { get; set; }
    }
}
