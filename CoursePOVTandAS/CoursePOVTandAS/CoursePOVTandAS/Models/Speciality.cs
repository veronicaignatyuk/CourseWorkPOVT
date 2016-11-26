using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePOVTandAS.Models
{
    public class Speciality
    {
        public int SpecialityId { get; set; } 
        public string Name { get; set; }
        public int CodeOfSpecialty { get; set; }

        public virtual ICollection<AcademicPlan> AcademicPlans { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

        public Speciality()
        {
            AcademicPlans = new HashSet<AcademicPlan>();
            Groups = new HashSet<Group>();
        }

    }
}