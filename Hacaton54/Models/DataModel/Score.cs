using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Score
    {
        public Score()
        {
            CourseWorks = new HashSet<CourseWork>();
        }

        public byte Id { get; set; }
        public string ScoreIndex { get; set; }

        public virtual ICollection<CourseWork> CourseWorks { get; set; }
    }
}
