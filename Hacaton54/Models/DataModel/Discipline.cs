using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Discipline
    {
        public Discipline()
        {
            DisciplineEmployees = new HashSet<DisciplineEmployee>();
        }

        public byte Id { get; set; }
        public string DisciplineName { get; set; }
        public byte DisciplineIndexId { get; set; }

        public virtual DisciplineIndex DisciplineIndex { get; set; }
        public virtual ICollection<DisciplineEmployee> DisciplineEmployees { get; set; }
    }
}
