using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class User
    {
        public User()
        {
            Employees = new HashSet<Employee>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public short RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
