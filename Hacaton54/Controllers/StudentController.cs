﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.ModelDB; 
using Hacaton54.Models.Repositories; 



namespace Hacaton54.Controllers
{
    public class StudentController : Controller
    {
        

        private ks54AISContext context; 

        private StudentRepository studentRepository;
        public StudentController(ks54AISContext _context)
        {
            this.context = _context; 
            //studentRepository = new StudentRepository(_context);     
        }
        

        public IActionResult ListStudents()
        { 
            List<Student> students = context.Students.ToList(); 
            return View(students);
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
