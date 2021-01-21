using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class AttestationStudent
    {
        public int Id { get; set; }
        public int AttestationId { get; set; }
        public int StudentId { get; set; }
        public byte? ScoreId { get; set; }
        public DateTime? HoldingDate { get; set; }

        public virtual Attestation Attestation { get; set; }
        public virtual Score Score { get; set; }
        public virtual Student Student { get; set; }
    }
}
