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

        private ks54AISContext context; 
        public UserController(ks54AISContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        public ActionResult Authorization()
        {
            //userRepository.AuthUser(); 

            context.Users.ToList();
            return null; 
            //return RedirectToAction("ListStudent"); 
        }

        public IActionResult Registration()
        {
            return View(); 
        }

      
    }
}
