using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel;

namespace Hacaton54.Models.Repositories
{
    public class GroupRepository : ModelRepository
    {

        private ks54AISContext context;
        public GroupRepository(ks54AISContext _context)
        {
            context = _context;
        }

        public List<Group> GetGroups()
        {
            return context.Groups.ToList();
        }
    }
}
