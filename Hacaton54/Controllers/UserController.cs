using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Hacaton54.Models.DataModel;
using Hacaton54.Models.Repositories;

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
            return View();
        }


        public ActionResult Authorization()
        {
            //TODO correct auth
            
            User testUser = new User() { UserName = "admin", Password = "123" }; 

            if (userRepository.AuthUser(testUser)){
                
            return RedirectToAction("ListStudents", "Student");
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
