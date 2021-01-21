using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.BackEnd;
using Hacaton54.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using Hacaton54.Models.Extensions;
using Microsoft.AspNetCore.Http;

namespace Hacaton54.Models.Repositories
{
    public class UserRepository : ModelRepository
    {
        
        public static User AuthorizedUser { get; set; }

        public static Employee AuthorizedEmployee { get; set; }

        private ks54AISContext context; 
        
        public UserRepository(ks54AISContext _context)
        {
            context = _context; 
        }
        

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

        public AccountModel GetAccountModel(string nameUser)
        {
            AuthorizedUser = context.Users.Where(i => i.UserName == nameUser).FirstOrDefault();

            AuthorizedEmployee = context.Employees.Where(i => i.UserId == AuthorizedUser.Id).FirstOrDefault();
                        
            var account = new AccountModel()
            {
                Name = AuthorizedEmployee.Name,
                Email = AuthorizedEmployee.EMail,
                Login = AuthorizedUser.UserName
            };

            return account; 
        }   

        public bool EditAccountData(AccountModel accountModel)
        {
            AuthorizedEmployee.Name = accountModel.Name;
            AuthorizedEmployee.EMail = accountModel.Email;
            AuthorizedUser.UserName = accountModel.Login;

            if(AuthorizedUser.Password == accountModel.OldPassword)
            {
                AuthorizedUser.Password = accountModel.NewPassword;
            }

            context.Employees.Update(AuthorizedEmployee);
            context.Users.Update(AuthorizedUser);

            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }


        public bool EditUser(User user)
        {
            return true; 
        }

        

        
    }
}
