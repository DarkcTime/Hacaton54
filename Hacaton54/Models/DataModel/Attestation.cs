using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Attestation
    {
        public Attestation()
        {
            AttestationStudents = new HashSet<AttestationStudent>();
        }

        public int Id { get; set; }
        public byte GroupId { get; set; }
        public short DisciplineId { get; set; }
        public byte FormId { get; set; }
        public short EmployeeId { get; set; }
        public byte? MonthId { get; set; }
        public byte ReadingHours { get; set; }

        public virtual AttestationForm Form { get; set; }
        public virtual Month Month { get; set; }
        public virtual ICollection<AttestationStudent> AttestationStudents { get; set; }
    }
}
