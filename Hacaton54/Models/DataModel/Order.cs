using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Order
    {
        public short Id { get; set; }
        public byte OrderTypeId { get; set; }
        public string Description { get; set; }
        public int StudentId { get; set; }

        public virtual OrderType OrderType { get; set; }
        public virtual Student Student { get; set; }
    }
}
