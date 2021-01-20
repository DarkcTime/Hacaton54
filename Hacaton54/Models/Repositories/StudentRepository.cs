﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.Extensions;
using Hacaton54.Models.ModelDB;
//package for Entity Framework
using Microsoft.EntityFrameworkCore;



namespace Hacaton54.Models.Repositories
{
    public class StudentRepository : ModelRepository
    {
        
        private ks54AISContext context; 
        public StudentRepository(ks54AISContext _context)
        {
            context = _context; 
        }

        //TODO получение студента по его id 
        public Student GetStudent(int id)
        {
            return new Student();
        }

        // TODO drenuv или нужно использовать студент View? можно перегрузить или просто создать классы с разными именами в случае чего 
        public List<Student> GetStudents()
        {
            return this.context.Students.Include(p => p.Group).ToList();
        }


        public List<Student> FoundStudents(string searchStr)
        {
            //TODO refactore code
            List<Student> students = new List<Student>();
            if (searchStr != null)
                students = context.Students.Include(p => p.Group).Where(i => i.Name != null && i.Name.Contains(searchStr)
                                               || i.SurName != null && i.SurName.Contains(searchStr)
                                               || i.Patronymic != null && i.Patronymic.Contains(searchStr)
                                               || i.Group.GroupName != null && i.Group.GroupName.Contains(searchStr))
                                                .ToList();
            else
                students = GetStudents();
            
            return students;

        }
      
        // TODO добавление студента
        public bool AddStudent(Student student)
        {
            return true; 
        }

        public void ImportStudentsFromExcel(List<Student> students)
        {
            foreach (Student student in students)
            {
                Student findStudent = context.Students.Find(student.Id);
                if(findStudent != null)
                {
                    context.Students.Update(findStudent);   
                }
                else
                {
                    context.Students.Add(student); 
                }
            }
            context.SaveChanges(); 
        }

        // TODO редактивароние данных о студенте
        public bool EditStudent(Student student)
        {
            //про этот метод почитай, он есть только в ef core. Потом надо протестить его будет, он у меня помню работал через раз (((( один раз работает, один нет
            //context.Students.Update(); 
            
            return true; 
        }


        
    }
}
