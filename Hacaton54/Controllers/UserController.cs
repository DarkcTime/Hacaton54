using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel; 
using Hacaton54.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Hacaton54.BackEnd.ExcelHelp;
using Hacaton54.Models.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Hacaton54.Controllers
{

    public class UserController : Controller
    {        
        private UserRepository userRepository;
        public UserController(ks54AISContext _context)
        {
            userRepository = new UserRepository(_context); 
        }    

             
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl )
        {
            if (ModelState.IsValid)
            {   
                if ( await userRepository.AuthUser(model))
                {
                    await Authenticate(UserRepository.AuthorizedUser); // аутентификация
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                    
                        return RedirectToAction("ListStudents", "Student");

                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            }
            return View(model);

        }
            
        
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        public IActionResult Account()
        {

            string login = HttpContext.User.Identity.Name; 

            return View(userRepository.GetAccountModel(login));
        }

        [HttpPost]
        public IActionResult Account(AccountModel account)
        {

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
    }
}
