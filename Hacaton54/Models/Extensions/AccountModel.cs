using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Models.Extensions
{
    public class AccountModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
