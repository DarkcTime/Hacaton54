using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class EducationDepartment
    {
        public EducationDepartment()
        {
            Groups = new HashSet<Group>();
        }

        public byte Id { get; set; }
        public byte DepartmentNumber { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
