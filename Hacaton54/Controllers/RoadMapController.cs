using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hacaton54.Controllers
{

    [Authorize]
    public class RoadMapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
