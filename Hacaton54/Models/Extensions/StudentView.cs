using Hacaton54.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Models.Extensions
{
    public class StudentView
    {
        public StudentView()    
        {

        
        }

        public StudentView(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            SurName = student?.SurName;
            Patronymic = student?.Patronymic;
            GroupName = student?.Group?.GroupName;
            BirthDate = student?.BirthDate;
            GenderName = student?.Gender?.Name;
            Phone = student?.Phone;
            HousePhone = student?.HousePhone;
            AdressFact = student?.AdressFact;
            MedPolicy = student?.MedPolicy;
            Snils = student?.Snils;
            Inn = student?.Inn;
            EMail = student?.EMail;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string? GroupName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string GenderName { get; set; }
        public string Phone { get; set; }
        public string HousePhone { get; set; }
        public string AdressFact { get; set; }
        public string MedPolicy { get; set; }
        public string Snils { get; set; }
        public string Inn { get; set; }
        public string EMail { get; set; }
    }
}
