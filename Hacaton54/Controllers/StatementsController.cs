using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel;
using Hacaton54.Models.Extensions;
using Hacaton54.BackEnd.ExcelHelp;
using Hacaton54.Models.Repositories;

namespace Hacaton54.Controllers
{
    public class StatementsController : Controller
    {

        private static List<AttestationStudent> students;

        private ExcelHelper excelHelper;

        private GroupRepository groupRepository;

        private StatementRepository statementRepository;

        public StatementsController(ks54AISContext _context)
        {
            //this.context = _context;             
            groupRepository = new GroupRepository(_context);
            excelHelper = new ExcelHelper(_context);
            statementRepository = new StatementRepository(_context);
        }

        public IActionResult CommonStatement()
        {
            students = statementRepository.GetAttestationStudents();
            return View(students);
        }

        public IActionResult ExportExcel()
        {
            return File(excelHelper.ExportExcelSCore(students),
                        "application/xlsx",
                        "road.xlsx");

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
