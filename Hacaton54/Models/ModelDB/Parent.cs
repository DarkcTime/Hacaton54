using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Parent
    {
        public Parent()
        {
            ParentStudents = new HashSet<ParentStudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<ParentStudent> ParentStudents { get; set; }
    }
}
