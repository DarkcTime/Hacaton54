using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel;

namespace Hacaton54.Models.Repositories
{
    public class GenderRepository
    {
        private ks54AISContext context;
        public GenderRepository(ks54AISContext _context)
        {
            context = _context;
        }

        public List<Gender> GetGenders()
        {
            return context.Genders.ToList();
        }

        public Gender FindGender(string nameGender)
        {
            return GetGenders().Find(i => i.Name == nameGender);
        }
    }
}
