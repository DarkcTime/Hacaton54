using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class TypeSertificate
    {
        public TypeSertificate()
        {
            EducationSertificates = new HashSet<EducationSertificate>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EducationSertificate> EducationSertificates { get; set; }
    }
}
