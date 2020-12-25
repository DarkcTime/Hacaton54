using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class DisciplineEmployee
    {
        public short Id { get; set; }
        public byte DisciplineId { get; set; }
        public short EmployeeId { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
