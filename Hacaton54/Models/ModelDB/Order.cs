using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Order
    {
        public Order()
        {
            OrderGroups = new HashSet<OrderGroup>();
            OrderScans = new HashSet<OrderScan>();
            OrderStudents = new HashSet<OrderStudent>();
        }

        public short Id { get; set; }
        public byte OrderTypeId { get; set; }
        public string Description { get; set; }

        public virtual OrderType OrderType { get; set; }
        public virtual ICollection<OrderGroup> OrderGroups { get; set; }
        public virtual ICollection<OrderScan> OrderScans { get; set; }
        public virtual ICollection<OrderStudent> OrderStudents { get; set; }
    }
}
