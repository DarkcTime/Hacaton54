using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.DataModel; 
using Hacaton54.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Hacaton54.BackEnd.ExcelHelp;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sql;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hacaton54.Controllers
{

    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
         

        //private ks54AISContext context;

        private static List<Student> studentsFromExcel; 

        private ExcelHelper excelHelper ; 

        private StudentRepository studentRepository;

        private static List<Student> Students { get; set; }

        private GroupRepository groupRepository; 

        private static int AllStudents;


        public StudentController(ks54AISContext _context)
        {
            //this.context = _context; 
            studentRepository = new StudentRepository(_context);
            groupRepository = new GroupRepository(_context);
            excelHelper = new ExcelHelper(_context);

        }
        
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
            return File(excelHelper.ExportExcelStudent(Students),
                        "application/xlsx",
                        "student.xlsx");

        }       
        public IActionResult ImportStudents()
        {
            return View(new List<Student>()); 
        }

        [HttpPost]
        public IActionResult ImportStudents(IFormFile uploadedFile)
        {
            studentsFromExcel = excelHelper.ImportExcel(uploadedFile);
            postData(0, studentsFromExcel.Count());
            return View(studentsFromExcel); 
        }

        public IActionResult AddStudentsToDataBase()
        {
            studentRepository.ImportStudentsFromExcel(studentsFromExcel); 
            return RedirectToAction("ImportStudents");
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

        
        public IActionResult EditStudent(int id)
        {
            Student student = studentRepository.GetStudent(id); 
            return View(student); 
        }

        //TODO drenuv контроллер для страницы редактирования
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            return View();
        }
    }
}
