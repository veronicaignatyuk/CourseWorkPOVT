using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWorkPOVTandAS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public User()
        {
            Roles = new HashSet<Role>();
        }
    }
}