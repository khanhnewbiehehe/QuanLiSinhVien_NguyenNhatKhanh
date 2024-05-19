using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiSinhVien.Models;

namespace QuanLiSinhVien.Controllers
{
    public class KhoaController : Controller
    {
        // GET: KhoaController
        public ActionResult Index(string searchTerm)
        {
            var context = new QlsinhvienContext();
            List<Khoa> listKhoa;
            if (string.IsNullOrEmpty(searchTerm))
            {
                listKhoa = context.Khoas.ToList();
            }
            else
            {
                listKhoa = context.Khoas.Where(k => k.TenKhoa.ToLower().Contains(searchTerm.ToLower())).ToList();
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
