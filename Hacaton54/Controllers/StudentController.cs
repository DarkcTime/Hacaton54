using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult ListStudents()
        {
            return View();
        }

        public IActionResult FilteringStudents()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
