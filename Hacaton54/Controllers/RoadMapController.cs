using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel;
using Hacaton54.BackEnd.ExcelHelp;
using Hacaton54.Models.Repositories;
using Microsoft.AspNetCore.Http;

namespace Hacaton54.Controllers
{

    [Authorize]
    public class RoadMapController : Controller
    {

        private ExcelHelper excelHelper = new ExcelHelper();       

        private GroupRepository groupRepository;

        private RoadMapRepository roadMapRepository;
     
        public RoadMapController(ks54AISContext _context)
        {
            //this.context = _context; 
            roadMapRepository = new RoadMapRepository(_context);
            groupRepository = new GroupRepository(_context);
        }

        public IActionResult CommonRoadMap()
        {
            List<RoadMap> roadMaps = roadMapRepository.GetRoadMaps(); 
            return View(roadMaps);
        }

        [HttpPost]
        public IActionResult CommonRoadMap(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {

            }
            return View(RoadMapRepository.RoadMaps);
        }
     
        public IActionResult ExportExcel()
        {
            return View(); 
        }

        public IActionResult AddRoadMap()
        {
            return View();
        }

        public IActionResult FilteringRoadMap()
        {
            return View();
        }

    }
}
