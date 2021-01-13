using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.ModelDB
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
