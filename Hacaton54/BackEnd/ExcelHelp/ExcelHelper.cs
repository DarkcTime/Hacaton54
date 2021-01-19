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
        public static byte[] ExportExcel()
        {
            using (ks54AISContext context = new ks54AISContext())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // library requirment 
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var workSheet = excel.Workbook.Worksheets.Add("Sheet1"); // new sheet
                    workSheet.Cells[1, 1].LoadFromCollection(context.Students.ToList(), true); // loading sheet
                    int cols = workSheet.Dimension.End.Column;  //get column count
                    workSheet.Cells[1, 1, 1, cols].AutoFilter = true; // filters for headers
                    using (var memoryStream = new MemoryStream()) //saving file
                    {
                        excel.SaveAs(memoryStream);
                        return memoryStream.ToArray();
                        //return File(ExcelHelper.ExportExcel(),
                        //            "application/xlsx",
                        //            "student.xlsx");
                    }
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

                            if (!String.IsNullOrWhiteSpace(row.Cell(1).GetString()))
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
