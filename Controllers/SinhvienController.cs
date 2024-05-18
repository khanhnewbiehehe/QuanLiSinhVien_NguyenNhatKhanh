using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiSinhVien.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QuanLiSinhVien.Controllers
{
    public class SinhvienController : Controller
    {
        // GET: SinhVienController
        public ActionResult Index()
        {
            var listSV = new QlsinhvienContext().Sinhviens.ToList();
            return View(listSV);
        }

        // GET: SinhVienController/Details/5
        public ActionResult Details(int id)
        {
           
            return View();
        }

        // GET: SinhVienController/Create
        public ActionResult Create()
        {
            var context = new QlsinhvienContext(); 
            var maxMaSv = context.Sinhviens.Max(sv => sv.MaSv);
            var nextMaSv = "SV" + (int.Parse(maxMaSv.Substring(2)) + 1).ToString("D8");
            ViewBag.NextMaSv = nextMaSv;
            return View();
        }

        // POST: SinhVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sinhvien model)
        {
            try
            {
                var context = new QlsinhvienContext();
                context.Sinhviens.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVienController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SinhVienController/Edit/5
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

        // GET: SinhVienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SinhVienController/Delete/5
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
