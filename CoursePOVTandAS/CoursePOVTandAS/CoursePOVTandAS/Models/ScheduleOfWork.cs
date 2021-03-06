﻿using System;
using System.Collections.Generic;

namespace CoursePOVTandAS.Models
{
    public partial class ScheduleOfWork
    {
        public int ScheduleOfWorkId { get; set; }
        public int AcademicPlanId { get; set; }
        public virtual AcademicPlan AcademicPlan { get; set; }
        public string StageName { get; set; }
        public DateTime ProjectedDate { get; set; }
        public int? PlannedPercent { get; set; }

        public virtual ICollection<GradualProgress> GradualProgress { get; set; }
        public ScheduleOfWork()
        {
            GradualProgress = new HashSet<GradualProgress>();
        }

    }
}
