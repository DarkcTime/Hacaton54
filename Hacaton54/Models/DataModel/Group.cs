using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public short Id { get; set; }
        public short GroupSpecialityId { get; set; }
        public byte GroupBase { get; set; }
        public byte GroupNumber { get; set; }
        public short GroupTypeId { get; set; }
        public short CuratorId { get; set; }
        public byte DepartmentId { get; set; }
        public byte StudyingTimeMonth { get; set; }
        public DateTime EducationBeginDate { get; set; }

        public virtual EducationDepartment Department { get; set; }
        public virtual GroupSpeciality GroupSpeciality { get; set; }
        public virtual GroupType GroupType { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
