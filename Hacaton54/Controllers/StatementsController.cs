using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Controllers
{
    public class StatementsController : Controller
    {
        public IActionResult CommonStatement()
        {
            return View();
        }

        public IActionResult AddStatement()
        {
            return View();
        }

        public IActionResult FilteringStatement()
        {
            return View();
        }
    }
}
