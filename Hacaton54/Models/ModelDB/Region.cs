using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Region
    {
        public Region()
        {
            EducationInstitutions = new HashSet<EducationInstitution>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EducationInstitution> EducationInstitutions { get; set; }
    }
}
