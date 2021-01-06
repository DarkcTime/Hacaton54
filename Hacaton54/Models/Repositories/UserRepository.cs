using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel; 

namespace Hacaton54.Models.Repositories
{
    public class UserRepository : ModelRepository
    {
        public static User AuthrizedUser { get; private set; }

        private ks54AISContext context; 

       

        //TODO drenuv - авторизации пользователя. 
        public bool AuthUser()
        {
            context.Users.ToList(); 
            return true; 
        }

        //TODO drenuv - изменение данных переданных пользвователю (Профиль пользователя)
        public bool EditUser(User user)
        {
            return true; 
        }
    }
}
