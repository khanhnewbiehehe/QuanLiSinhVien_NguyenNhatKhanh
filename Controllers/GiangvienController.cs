using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiSinhVien.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuanLiSinhVien.Controllers
{
    public class GiangvienController : Controller
    {
        // GET: GiangvienController
        public ActionResult Index(string searchTerm)
        {
            var context = new QlsinhvienContext();
            List<Giangvien> listGV;
            if (string.IsNullOrEmpty(searchTerm))
            {
                listGV = context
                    .Giangviens
                    .Include(gv => gv.MaKhoaNavigation)
                    .ToList();
            }
            else
            {
                listGV = context
                    .Giangviens
                    .Where(gv => gv.TenGv.ToLower().Contains(searchTerm.ToLower()) ||
                         gv.MaKhoaNavigation.TenKhoa.ToLower().Contains(searchTerm.ToLower()))
                    .Include(gv => gv.MaKhoaNavigation)
                    .ToList();
            }
            return View(listGV);
        }

        // GET: GiangvienController/Details/5
        public ActionResult Details(int id)
        {
           
            return View();
        }

        // GET: GiangvienController/Create
        public ActionResult Create()
        {
            var context = new QlsinhvienContext();
            var maKhoaSelect = new SelectList(context.Khoas.ToList(), "MaKhoa", "TenKhoa");
            var maxMaGv = context.Giangviens.Max(gv => gv.MaGv);
            var nextMaGv = "GV" + (int.Parse(maxMaGv.Substring(2)) + 1).ToString("D8");
            ViewBag.MaKhoa = maKhoaSelect;
            ViewBag.NextMaGv = nextMaGv;
            return View();
        }

        // POST: GiangvienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Giangvien model)
        {
            try
            {
                var context = new QlsinhvienContext();
                context.Giangviens.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GiangvienController/Edit/5
        public ActionResult Edit()
        {
            var context = new QlsinhvienContext();
            var maKhoaSelect = new SelectList(context.Khoas.ToList(), "MaKhoa", "TenKhoa");
            ViewBag.MaKhoa = maKhoaSelect;
            return View();
        }

        // POST: GiangvienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Giangvien model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var giangvienToUpdate = context.Giangviens.Find(model.MaGv);
                if (giangvienToUpdate == null)
                {
                    return NotFound();
                }
                giangvienToUpdate.TenGv = model.TenGv;
                giangvienToUpdate.Ngaysinh = model.Ngaysinh;
                giangvienToUpdate.Cccd = model.Cccd;
                giangvienToUpdate.Sdt = model.Sdt;
                giangvienToUpdate.Email = model.Email;
                giangvienToUpdate.Hocvi = model.Hocvi;
                giangvienToUpdate.MaKhoa = model.MaKhoa;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GiangvienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GiangvienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Giangvien model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var giangvienToDelete = context.Giangviens.Find(model.MaGv);

                if (giangvienToDelete == null)
                {
                    return NotFound();
                }
                context.Giangviens.Remove(giangvienToDelete);
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
