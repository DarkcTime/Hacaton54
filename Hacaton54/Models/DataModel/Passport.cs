using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Passport
    {
        public int Id { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public string Registration { get; set; }
        public string DivisionCode { get; set; }
        public string IssuedBy { get; set; }
        public bool IsActual { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
