﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLiSinhVien.Models;

namespace QuanLiSinhVien.Controllers
{
    public class KhoaController : Controller
    {
        // GET: KhoaController
        public ActionResult Index(string searchTerm , string selectedMaKhoa)
        {
            var context = new QlsinhvienContext();
            List<Khoa> listKhoa;

            ViewBag.ListMaKhoa = new SelectList(context.Khoas, "MaKhoa", "MaKhoa");

            if (string.IsNullOrEmpty(searchTerm) && string.IsNullOrEmpty(selectedMaKhoa))
            {
                listKhoa = context.Khoas.ToList();
            }
            else
            {
                listKhoa = context.Khoas
                    .Where(k => (string.IsNullOrEmpty(searchTerm) || k.TenKhoa.ToLower().Contains(searchTerm.ToLower()))&&
                    (string.IsNullOrEmpty(selectedMaKhoa) || k.MaKhoa == selectedMaKhoa))
                    .ToList();
            }
            return View(listKhoa);
        }

        // GET: KhoaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Khoa model)
        {
            try
            {
                var context = new QlsinhvienContext();
                context.Khoas.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KhoaController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: KhoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Khoa model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var khoaToUpdate = context.Khoas.Find(model.MaKhoa);
                if (khoaToUpdate == null)
                {
                    return NotFound(); 
                }
                khoaToUpdate.TenKhoa = model.TenKhoa;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
            return View(model);
        }

        // GET: KhoaController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: KhoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Khoa model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var khoaToDelete = context.Khoas.Find(model.MaKhoa);

                if (khoaToDelete == null)
                {
                    return NotFound(); 
                }
                context.Khoas.Remove(khoaToDelete);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
