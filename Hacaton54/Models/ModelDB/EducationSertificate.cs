using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class EducationSertificate
    {
        public int Id { get; set; }
        public byte TypeId { get; set; }
        public string SertificateNumber { get; set; }
        public int EducationInstitutionId { get; set; }
        public int StudentId { get; set; }
        public decimal AvgScore { get; set; }

        public virtual EducationInstitution EducationInstitution { get; set; }
        public virtual Student Student { get; set; }
        public virtual TypeSertificate Type { get; set; }
    }
}
