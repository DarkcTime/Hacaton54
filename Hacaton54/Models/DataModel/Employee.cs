using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Employee
    {
        public Employee()
        {
            CourseWorks = new HashSet<CourseWork>();
            DisciplineEmployees = new HashSet<DisciplineEmployee>();
            EducationDepartments = new HashSet<EducationDepartment>();
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int? UserId { get; set; }
        public string EMail { get; set; }
        public byte GenderId { get; set; }
        public short PositionId { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual EmployeePosition Position { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CourseWork> CourseWorks { get; set; }
        public virtual ICollection<DisciplineEmployee> DisciplineEmployees { get; set; }
        public virtual ICollection<EducationDepartment> EducationDepartments { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
