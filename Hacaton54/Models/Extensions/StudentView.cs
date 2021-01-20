using Hacaton54.Models.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Models.Extensions
{
    //TODO drenuv - расширить класс. 
    public class StudentView
    {
        public StudentView()    
        {

        
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
        public int? Inn { get; set; }
        public string EMail { get; set; }
    }
}
