using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string name { get; set; }

        virtual public ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}