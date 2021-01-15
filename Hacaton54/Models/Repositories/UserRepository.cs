using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.BackEnd;
using Hacaton54.Models.ModelDB;
using Microsoft.EntityFrameworkCore;
using Hacaton54.Models.Extensions;


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
        public async Task<bool> AuthUser(LoginModel model)
        {
            User user = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

            if(user != null)
            {
                AuthorizedUser = user; 
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
