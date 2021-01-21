using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class RoadMap
    {
        public int Id { get; set; }
        public int AttestationId { get; set; }
        public short GroupId { get; set; }
        public DateTime Year { get; set; }

        public virtual Attestation Attestation { get; set; }
        public virtual Group Group { get; set; }
    }
}
