using System;
using System.Collections.Generic;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class GroupSpeciality
    {
        public GroupSpeciality()
        {
            Groups = new HashSet<Group>();
        }

        public short Id { get; set; }
        public string SpecialityCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
