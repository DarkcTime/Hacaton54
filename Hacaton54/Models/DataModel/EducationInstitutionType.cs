using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class EducationInstitutionType
    {
        public EducationInstitutionType()
        {
            EducationInstitutions = new HashSet<EducationInstitution>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EducationInstitution> EducationInstitutions { get; set; }
    }
}
