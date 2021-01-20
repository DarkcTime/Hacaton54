using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.ModelDB; 
using Hacaton54.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Hacaton54.BackEnd.ExcelHelp;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hacaton54.Controllers
{

    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
         

        private ks54AISContext context;

        private ExcelHelper excelHelper = new ExcelHelper(); 

        private StudentRepository studentRepository;
        private GroupRepository groupRepository;
        public StudentController(ks54AISContext _context)
        {
            //this.context = _context; 
            studentRepository = new StudentRepository(_context);
            groupRepository = new GroupRepository(_context);
        }

        private static List<Student> Students { get; set; }

        private static int AllStudents; 

        public IActionResult ListStudents()
        { 
            Students = studentRepository.GetStudents();
            AllStudents = Students.Count();
            postData(AllStudents, AllStudents);
            return View(Students);
        }

        [HttpPost]
        public IActionResult ListStudents(string searchString)
        { 
            List<Student> students = studentRepository.FoundStudents(searchString);
            int countStudents = students.Count();
            postData(countStudents, AllStudents);
            Students = students; 
            return View(students);
        }

        public IActionResult ExportExcel()
        {
            return File(excelHelper.ExportExcel(Students),
                        "application/xlsx",
                        "student.xlsx");

        }       
        public IActionResult ImportStudents()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult ImportStudents(IFormFile uploadFile)
        {
            return View(); 
        }

        private void postData(int count, int all)
        {
            ViewData["Count"] = count.ToString();
            ViewData["All"] = all.ToString();            
        }



        public IActionResult FilteringStudents()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            ViewData["AllGroup"] = GetGroup();
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (studentRepository.AddStudent(student))
            {

            }
            ViewData["AllGroup"] = GetGroup();
            return View();
        }

        private SelectList GetGroup()
        {
            return new SelectList(groupRepository.GetGroups(), "Id", "GroupName");
        }
    }
}
