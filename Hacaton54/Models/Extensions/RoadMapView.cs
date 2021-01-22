using Hacaton54.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Models.Extensions
{
    public class RoadMapView
    {
        public RoadMapView()
        {

        }

        public RoadMapView(RoadMap roadMap)
        {
            Id = roadMap.Id;
            HeadOfDepartment = roadMap.Group.Department.HeadOfDepartmentNavigation.Surname;
            DepartmentName = roadMap.Group.Department.Name;
            GroupSpeciality = roadMap.Group.GroupSpeciality.Description;
            GroupName = roadMap.Group.GroupName;
            DisciplineName = roadMap.Attestation.DisciplineEmployee.Discipline.Name;
            IndexDiscipline = roadMap.Attestation.DisciplineEmployee.Discipline.DisciplineIndex.Name;
            EmployeeSurname = roadMap.Attestation.DisciplineEmployee.Employee.Surname;
            MonthName = roadMap.Attestation.Month.Name;
            FormAttestation = roadMap.Attestation.Form.Name;
            Year = roadMap.Year;

        }
        public int Id { get; set; }
        public string HeadOfDepartment { get; set; }
        public string DepartmentName { get; set; }
        public string GroupSpeciality { get; set; }
        public string GroupName { get; set; }
        public string DisciplineName { get; set; }
        public string IndexDiscipline { get; set; }
        public string EmployeeSurname { get; set; }
        public string MonthName { get; set; }
        public string FormAttestation { get; set; }
        public DateTime Year { get; set; }




    }
}
