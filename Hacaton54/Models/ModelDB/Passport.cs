using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Passport
    {
        public Passport()
        {
            PassportScans = new HashSet<PassportScan>();
        }

        public int Id { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public string Registration { get; set; }
        public string DivisionCode { get; set; }
        public string IssuedBy { get; set; }
        public bool IsActual { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<PassportScan> PassportScans { get; set; }
    }
}
