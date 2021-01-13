using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class ParentStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ParentId { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
    }
}
