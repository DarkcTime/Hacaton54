using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class DisciplineIndex
    {
        public DisciplineIndex()
        {
            Disciplines = new HashSet<Discipline>();
        }

        public byte Id { get; set; }
        public string Index { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
