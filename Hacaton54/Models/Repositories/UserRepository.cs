using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.BackEnd;
using Hacaton54.Models.ModelDB; 


namespace Hacaton54.Models.Repositories
{
    public class UserRepository : ModelRepository
    {
        
        public static User AuthorizedUser { get; private set; }

        private ks54AISContext context; 

        
        public UserRepository(ks54AISContext _context)
        {
            context = _context; 
        }
        

        //TODO drenuv - авторизации пользователя. 
        public bool AuthUser(User _user)
        {
            
            
            var user = context.Users.Where(i => _user.UserName == i.UserName && _user.Password == i.Password); 
            if(user.Count() > 0)
            {                 
                AuthorizedUser = user.FirstOrDefault();
                return true;
            }
            return false;
            
            
        }

        //TODO drenuv - изменение данных переданных пользвователю (Профиль пользователя)
        public bool EditUser(User user)
        {
            return true; 
        }
        
    }
}
