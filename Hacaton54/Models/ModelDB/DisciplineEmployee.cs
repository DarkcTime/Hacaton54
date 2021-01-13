using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class DisciplineEmployee
    {
        public DisciplineEmployee()
        {
            Attestations = new HashSet<Attestation>();
        }

        public int Id { get; set; }
        public byte DisciplineId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Attestation> Attestations { get; set; }
    }
}
