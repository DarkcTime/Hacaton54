using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using ClosedXML.Excel; // another library for Excel
using OfficeOpenXml; // main library to work with Excel
using Hacaton54.Models.DataModel;
using Microsoft.AspNetCore.Http;
using Hacaton54.Models.Extensions;
using Hacaton54.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hacaton54.BackEnd.ExcelHelp
{
    public class ExcelHelper
    {
        private GroupRepository groupRepository;
        private GenderRepository genderRepository;
        public ExcelHelper(ks54AISContext context = null)
        {
            if (context != null)
            {
            
                groupRepository = new GroupRepository(context);
                genderRepository = new GenderRepository(context);
            }
        }

        
        public byte[] ExportExcel(List<Student> students)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // library requirment 
            var studentView = students.Select(i => new StudentView(i)

            ).ToList();
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1"); // new sheet
                workSheet.Cells[1, 1].LoadFromCollection(studentView, true); // loading sheet
                int cols = workSheet.Dimension.End.Column;  //get column count
                workSheet.Cells[1, 1, 1, cols].AutoFilter = true; // filters for headers
                using (var memoryStream = new MemoryStream()) //saving file
                {
                    excel.SaveAs(memoryStream);
                    return memoryStream.ToArray();

                }
            }
        }


        public List<Student> ImportExcel(IFormFile file)
        {

            FileInfo fileInfo = new FileInfo(file.FileName);

            List<Student> students = new List<Student>();
            

            if (fileInfo.Extension.ToLower() == ".xlsx")
            {
                // reading the Excel file using ClosedXML
                using (XLWorkbook workbook = new XLWorkbook(file.OpenReadStream()))
                {

                    IXLWorksheet worksheet = workbook.Worksheet(1); //  go to the first sheet
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        //TODO no test
                        if (row.RowNumber() == 1)
                            continue;

                        Student student = new Student();

                        if (!row.Cell(1).IsEmpty())
                        {
                            student.Id = Convert.ToInt32(row.Cell(1).Value.ToString().Trim()); 
                        }

                        student.Name = row.Cell(2).Value.ToString().Trim();
                        if (!row.Cell(3).IsEmpty())
                            student.SurName = row?.Cell(3)?.Value?.ToString()?.Trim();
                        if (!row.Cell(4).IsEmpty())
                            student.Patronymic = row?.Cell(4)?.Value?.ToString()?.Trim();
                        if (!row.Cell(4).IsEmpty())
                            student.Patronymic = row?.Cell(4)?.Value?.ToString()?.Trim();
                        if (!row.Cell(5).IsEmpty())
                        {
                            student.Group = groupRepository.FindGroup(row?.Cell(5)?.Value?.ToString()?.Trim());
                            student.GroupId = student.Group.Id;
                        }

                        if (!row.Cell(6).IsEmpty())
                            student.BirthDate = row.Cell(6).GetDateTime();
                        if (!row.Cell(7).IsEmpty())
                        {
                            student.Gender = genderRepository.FindGender( row.Cell(7).Value?.ToString()?.Trim());
                            student.GenderId = student.Gender.Id;
                        }

                        if (!row.Cell(8).IsEmpty())
                            student.Phone = row?.Cell(8)?.Value?.ToString()?.Trim();
                        if (!row.Cell(9).IsEmpty())
                            student.HousePhone = row?.Cell(9)?.Value?.ToString()?.Trim();
                        if (!row.Cell(10).IsEmpty())
                            student.AdressFact = row?.Cell(10)?.Value?.ToString()?.Trim();
                        if (!row.Cell(11).IsEmpty())
                            student.MedPolicy = row?.Cell(11)?.Value?.ToString()?.Trim();
                        if (!row.Cell(12).IsEmpty())
                            student.Snils = row?.Cell(12)?.Value?.ToString()?.Trim();
                        if (!row.Cell(13).IsEmpty())
                            student.Inn = row?.Cell(13)?.Value?.ToString()?.Trim();
                        if (!row.Cell(14).IsEmpty())
                            student.EMail = row?.Cell(14)?.Value?.ToString()?.Trim();
                        //if (!row.Cell(15).IsEmpty()) userId
                        //    student.UserId = row?.Cell(15)?.Value?.ToString()?.Trim();

                        students.Add(student);

                    }
                } 
            }
            else
            {
                //            ////If file extension of the uploaded file is different then .xlsx
                //            
            }

            return students; 

        }    
    }
}
