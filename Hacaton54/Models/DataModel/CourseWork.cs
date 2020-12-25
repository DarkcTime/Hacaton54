using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class CourseWork
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime DeadLine { get; set; }
        public byte? ScoreId { get; set; }
        public int StudentId { get; set; }
        public short? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Score Score { get; set; }
        public virtual Student Student { get; set; }
    }
}
