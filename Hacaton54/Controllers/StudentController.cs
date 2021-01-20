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

    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
         

        private ks54AISContext context; 

        private StudentRepository studentRepository;
        public StudentController(ks54AISContext _context)
        {
            //this.context = _context; 
            studentRepository = new StudentRepository(_context);     
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
            return View(students);
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
            return View();
        }
    }
}
