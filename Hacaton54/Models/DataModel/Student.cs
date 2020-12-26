using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class Student
    {
        public Student()
        {
            AttestationStudents = new HashSet<AttestationStudent>();
            CourseWorks = new HashSet<CourseWork>();
            EducationSertificates = new HashSet<EducationSertificate>();
            Orders = new HashSet<Order>();
            ParentStudents = new HashSet<ParentStudent>();
            Passports = new HashSet<Passport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public short GroupId { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte GenderId { get; set; }
        public string Phone { get; set; }
        public string HousePhone { get; set; }
        public string AdressFact { get; set; }
        public string MedPolicy { get; set; }
        public string Snils { get; set; }
        public int? Inn { get; set; }
        public string EMail { get; set; }
        public int? UserId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AttestationStudent> AttestationStudents { get; set; }
        public virtual ICollection<CourseWork> CourseWorks { get; set; }
        public virtual ICollection<EducationSertificate> EducationSertificates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ParentStudent> ParentStudents { get; set; }
        public virtual ICollection<Passport> Passports { get; set; }
    }
}
