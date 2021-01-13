using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class OrderScan
    {
        public short Id { get; set; }
        public short OrderId { get; set; }
        public byte[] Image { get; set; }
        public string Format { get; set; }

        public virtual Order Order { get; set; }
    }
}
