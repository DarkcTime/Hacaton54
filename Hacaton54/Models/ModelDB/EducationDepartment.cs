using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class EducationDepartment
    {
        public EducationDepartment()
        {
            Groups = new HashSet<Group>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public int HeadOfDepartment { get; set; }

        public virtual Employee HeadOfDepartmentNavigation { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
