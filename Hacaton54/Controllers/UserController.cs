using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.ModelDB; 
using Hacaton54.Models.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Hacaton54.Controllers
{

    public class UserController : Controller
    {
        

        private UserRepository userRepository;
        public UserController(ks54AISContext _context)
        {
            userRepository = new UserRepository(_context); 
        }                    
        
        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return Content("не аутентифицирован");
        }


        public ActionResult Authorization()
        {
            //TODO correct auth

            return RedirectToAction("ListStudents", "Student");

            
            User testUser = new User() { UserName = "admin", Password = "123" }; 

            if (userRepository.AuthUser(testUser)){
                
            
            }
            else
            {             
                return null;
            } 
            
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}
