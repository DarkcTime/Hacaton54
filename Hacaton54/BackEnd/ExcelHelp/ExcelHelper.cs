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
using Hacaton54.Models.ModelDB;
using Microsoft.AspNetCore.Http;

namespace Hacaton54.BackEnd.ExcelHelp
{
    public class ExcelHelper
    {
        public byte[] ExportExcel(List<Student> students)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // library requirment 
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1"); // new sheet
                workSheet.Cells[1, 1].LoadFromCollection(students, true); // loading sheet
                int cols = workSheet.Dimension.End.Column;  //get column count
                workSheet.Cells[1, 1, 1, cols].AutoFilter = true; // filters for headers
                using (var memoryStream = new MemoryStream()) //saving file
                {
                    excel.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                   
                }
            }
        }


        public static void ImportExcel(IFormFile file)
        {

            FileInfo fileInfo = new FileInfo(file.FileName);
            using (ks54AISContext context = new ks54AISContext())
            {
                if (fileInfo.Extension.ToLower() == ".xlsx")
                {
                    // reading the Excel file using ClosedXML
                    using (XLWorkbook workbook = new XLWorkbook(file.OpenReadStream()))
                    {

                        IXLWorksheet worksheet = workbook.Worksheet(1); //  go to the first sheet
                        bool FirstRow = true;
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (FirstRow == true)
                            {
                                FirstRow = false;
                                continue;
                            }
                            int id = 0;
                            Student student = null;

                            if (!row.Cell(1).IsEmpty())
                            {
                                id = row.Cell(1).GetValue<int>();
                                student = context.Students.Find(id); // searching Excel row in EF
                            }

                            if (student == null)
                            {
                                student = new Student();
                                context.Students.Add(student);
                            }
                            student.Name = row.Cell(2).Value.ToString().Trim();
                            if (!row.Cell(3).IsEmpty())
                                student.SurName = row?.Cell(3)?.Value?.ToString()?.Trim();
                            if (!row.Cell(4).IsEmpty())
                                student.Patronymic = row?.Cell(4)?.Value?.ToString()?.Trim();
                            if (!row.Cell(4).IsEmpty())
                                student.Patronymic = row?.Cell(4)?.Value?.ToString()?.Trim();
                            //if (!row.Cell(5).IsEmpty())группа id
                            //    student.GroupId = row?.Cell(5)?.Value?.ToString()?.Trim();
                            if (!row.Cell(6).IsEmpty())
                                student.BirthDate = row.Cell(6).GetDateTime();
                            //if (!row.Cell(7).IsEmpty()) genderid
                            //    student.Gender = row.Cell(7).Value?.ToString()?.Trim();
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
                            //if (!row.Cell(13).IsEmpty())
                            //    student.Inn = row?.Cell(13)?.Value?.ToString()?.Trim();
                            if (!row.Cell(14).IsEmpty())
                                student.EMail = row?.Cell(14)?.Value?.ToString()?.Trim();
                            //if (!row.Cell(15).IsEmpty()) userId
                            //    student.UserId = row?.Cell(15)?.Value?.ToString()?.Trim();

                        }
                        if (FirstRow) //If no data in Excel file
                        {
                            return;
                        }
                    }
                    context.SaveChanges();
                }
                else
                {
                    //            ////If file extension of the uploaded file is different then .xlsx
                    //            
                }
            }
        }

    }
}
