using Hacaton54.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Models.Extensions
{
    public class ScoreView
    {
        public ScoreView()
        {

        }

        public ScoreView(AttestationStudent attestation)
        {
            name = attestation.Student.SurName + " " + attestation.Student.Name + " " + attestation.Student.Patronymic;
            group = attestation.Student.Group?.GroupName;
            Discipline = attestation.Attestation.DisciplineEmployee.Discipline.Name;
            score = attestation.Score.Name;
            HolingDate = attestation?.HoldingDate;
        }
        public string name { get; set; }
        public string group { get; set; }
        public string Discipline { get; set; }
        public string score { get; set; }

        public DateTime? HolingDate { get; set; }


    }
}
