using Hacaton54.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hacaton54.Models.Repositories
{
    public class StatementRepository
    {
        private ks54AISContext context;

        public static List<AttestationStudent> AttestationStudents { get; private set; }

        public StatementRepository(ks54AISContext _context)
        {
            this.context = _context;
        }

        public List<AttestationStudent> GetAttestationStudents()
        {
            AttestationStudents = context.AttestationStudents
                .Include(p => p.Student)
                .Include(p => p.Student.Group)
                .Include(p => p.Attestation.DisciplineEmployee.Discipline)
                .Include(p => p.Score)              
                .ToList();
            return AttestationStudents;
        }

    }
}
