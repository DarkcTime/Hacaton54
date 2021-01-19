using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hacaton54.Models.Extensions;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Hacaton54.BackEnd.ExcelHelp;

namespace Hacaton54.Controllers
{
    public class FileController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                //return File(ExcelHelper.ExportExcel(),
                //            "application/xlsx",
                //            "student.xlsx");
                ExcelHelper.ImportExcel(uploadedFile);
                
            }

            return RedirectToAction("Index");
        }

        // GET: FileController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FileController/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
