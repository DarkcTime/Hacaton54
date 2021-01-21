using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.Extensions;
using Hacaton54.Models.DataModel;
//package for Entity Framework
using Microsoft.EntityFrameworkCore;


namespace Hacaton54.Models.Repositories
{
    public class AttestationStudentRepository
    {
        private ks54AISContext context;
        public AttestationStudentRepository(ks54AISContext _context)
        {
            context = _context;
        }

        public List<AttestationStudent> GetAttestationStudent()
        {
            return context.AttestationStudents
                .Include(p => p.Score)
                .Include(p => p.Student)
                .Include(p => p.Student.Group )
                .Include(p => p.Attestation)
                .Include(p => p.Attestation.DisciplineEmployee)
                .Include(p => p.Attestation.DisciplineEmployee.Discipline)
                .ToList();
        }
    }
}
