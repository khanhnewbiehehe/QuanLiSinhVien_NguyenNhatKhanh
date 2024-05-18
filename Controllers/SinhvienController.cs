using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiSinhVien.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var maLshSelect = new SelectList(context.Lshes.ToList(),"MaLsh", "MaLsh");
            var maxMaSv = context.Sinhviens.Max(sv => sv.MaSv);
            var nextMaSv = "SV" + (int.Parse(maxMaSv.Substring(2)) + 1).ToString("D8");
            ViewBag.NextMaSv = nextMaSv;
            ViewBag.MaLsh = maLshSelect;
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
        public ActionResult Edit(Sinhvien model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var sinhvientoupdate = context.Sinhviens.Find(model.MaSv);
                if (sinhvientoupdate != null)
                {
                    return NotFound();
                }
                sinhvientoupdate.TenSv = model.TenSv;
                sinhvientoupdate.Ngaysinh = model.Ngaysinh;
                sinhvientoupdate.Cccd = model.Cccd;
                sinhvientoupdate.Sdt = model.Sdt;
                sinhvientoupdate.Email = model.Email;
                sinhvientoupdate.MaLsh = model.MaLsh;
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
