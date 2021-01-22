using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class GroupType
    {
        public GroupType()
        {
            Groups = new HashSet<Group>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
