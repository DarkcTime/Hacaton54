using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Hacaton54.Models.Repositories
{
    public class RoadMapRepository : ModelRepository
    {
        private ks54AISContext context;

        public static List<RoadMap> RoadMaps { get; private set; }

        public RoadMapRepository(ks54AISContext _context)
        {
            this.context = _context; 
        }

        public List<RoadMap> GetRoadMaps()
        {
            RoadMaps = context.RoadMaps.Include(p => p.Group.Department)
                .Include(p => p.Group)
                .Include(p => p.Group.Department.HeadOfDepartmentNavigation)
                .Include(p => p.Group.GroupSpeciality)
                .Include(p => p.Attestation)
                .Include(p => p.Attestation.Month)
                .Include(p => p.Attestation.Form)
                .Include(p => p.Attestation.DisciplineEmployee.Employee)
                .Include(p => p.Attestation.DisciplineEmployee.Discipline)
                .Include(p => p.Attestation.DisciplineEmployee.Discipline.DisciplineIndex)
                .ToList();
            return RoadMaps; 
        }

        public List<RoadMap> GetSearchedRoadMaps(string search)
        {
            List<RoadMap> roadMaps = context.RoadMaps
                .Include(p => p.Group)
                .Include(p => p.Group.Department.HeadOfDepartmentNavigation)
                .Include(p => p.Group.GroupSpeciality)
                .Include(p => p.Attestation)
                .Include(p => p.Attestation.Month)
                .Include(p => p.Attestation.Form)
                .Include(p => p.Attestation.DisciplineEmployee.Employee)
                .Include(p => p.Attestation.DisciplineEmployee.Discipline)
                .Include(p => p.Attestation.DisciplineEmployee.Discipline.DisciplineIndex)
                .Where(i => i.Group.GroupName.Contains(search)
            || i.Attestation.DisciplineEmployee.Employee.Surname.Contains(search)).ToList();

            return roadMaps;
        }

        

    }
}
