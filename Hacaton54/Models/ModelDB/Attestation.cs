using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Attestation
    {
        public Attestation()
        {
            AttestationStudents = new HashSet<AttestationStudent>();
        }

        public int Id { get; set; }
        public short GroupId { get; set; }
        public byte FormId { get; set; }
        public byte? MonthId { get; set; }
        public byte ReadingHours { get; set; }
        public int DisciplineEmployeeId { get; set; }

        public virtual DisciplineEmployee DisciplineEmployee { get; set; }
        public virtual AttestationForm Form { get; set; }
        public virtual Group Group { get; set; }
        public virtual Month Month { get; set; }
        public virtual ICollection<AttestationStudent> AttestationStudents { get; set; }
    }
}
