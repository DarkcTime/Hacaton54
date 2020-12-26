using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Gender
    {
        public Gender()
        {
            Employees = new HashSet<Employee>();
            Students = new HashSet<Student>();
        }

        public byte Id { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
