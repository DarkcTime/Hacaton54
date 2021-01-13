using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class EducationInstitution
    {
        public EducationInstitution()
        {
            EducationSertificates = new HashSet<EducationSertificate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte TypeInstitutionId { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual EducationInstitutionType TypeInstitution { get; set; }
        public virtual ICollection<EducationSertificate> EducationSertificates { get; set; }
    }
}
