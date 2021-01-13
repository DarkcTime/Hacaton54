using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Month
    {
        public Month()
        {
            Attestations = new HashSet<Attestation>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attestation> Attestations { get; set; }
    }
}
