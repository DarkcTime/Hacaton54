﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Group
    {
        public Group()
        {
            OrderGroups = new HashSet<OrderGroup>();
            RoadMaps = new HashSet<RoadMap>();
            Students = new HashSet<Student>();
        }

        public short Id { get; set; }
        public int CuratorId { get; set; }
        public short GroupSpecialityId { get; set; }
        public byte GroupBase { get; set; }
        public string GroupName { get; set; }
        public short GroupTypeId { get; set; }
        public byte DepartmentId { get; set; }
        public byte StudyingTimeMonth { get; set; }
        public DateTime EducationBeginDate { get; set; }

        public virtual Employee Curator { get; set; }
        public virtual EducationDepartment Department { get; set; }
        public virtual GroupSpeciality GroupSpeciality { get; set; }
        public virtual GroupType GroupType { get; set; }
        public virtual ICollection<OrderGroup> OrderGroups { get; set; }
        public virtual ICollection<RoadMap> RoadMaps { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
