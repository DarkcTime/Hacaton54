using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class OrderStudent
    {
        public int Id { get; set; }
        public short OrderId { get; set; }
        public int StudentId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Student Student { get; set; }
    }
}
