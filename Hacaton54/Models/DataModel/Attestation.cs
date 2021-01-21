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
            RoadMaps = new HashSet<RoadMap>();
        }

        public int Id { get; set; }
        public byte FormId { get; set; }
        public byte? MonthId { get; set; }
        public byte ReadingHours { get; set; }
        public int DisciplineEmployeeId { get; set; }

        public virtual DisciplineEmployee DisciplineEmployee { get; set; }
        public virtual AttestationForm Form { get; set; }
        public virtual Month Month { get; set; }
        public virtual ICollection<AttestationStudent> AttestationStudents { get; set; }
        public virtual ICollection<RoadMap> RoadMaps { get; set; }
    }
}
