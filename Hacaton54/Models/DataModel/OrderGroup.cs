using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class OrderGroup
    {
        public int Id { get; set; }
        public short GroupId { get; set; }
        public short OrderId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Order Order { get; set; }
    }
}
