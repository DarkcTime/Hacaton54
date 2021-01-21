using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class PassportScan
    {
        public int Id { get; set; }
        public int PassportId { get; set; }
        public byte[] Image { get; set; }
        public string Format { get; set; }

        public virtual Passport Passport { get; set; }
    }
}
