using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursePOVTandAS.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int GroupNumber { get; set; }
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public Group()
        {
            Students = new HashSet<Student>();
        }

    }
}