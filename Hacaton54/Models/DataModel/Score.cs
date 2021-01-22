using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Score
    {
        public Score()
        {
            AttestationStudents = new HashSet<AttestationStudent>();
            CourseWorks = new HashSet<CourseWork>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AttestationStudent> AttestationStudents { get; set; }
        public virtual ICollection<CourseWork> CourseWorks { get; set; }
    }
}
