using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiSinhVien.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace QuanLiSinhVien.Controllers
{
    public class LshController : Controller
    {
        // GET: LshController
        public ActionResult Index()
        {
            var listLsh = new QlsinhvienContext()
                     .Lshes
                     .Include(lsh => lsh.MaGvNavigation)
                     .ToList();
            return View(listLsh);
        }

        // GET: LshController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LshController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LshController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lsh model)
        {
            try
            {
                var context = new QlsinhvienContext();
                context.Lshes.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LshController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LshController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lsh model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var LshToUpdate = context.Lshes.Find(model.MaLsh);
                if (LshToUpdate == null)
                {
                    return NotFound();
                }
                LshToUpdate.MaGv = model.MaGv;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LshController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LshController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Lsh model)
        {
            try
            {
                var context = new QlsinhvienContext();
                var LshToDelete = context.Lshes.Find(model.MaLsh);

                if (LshToDelete == null)
                {
                    return NotFound();
                }
                context.Lshes.Remove(LshToDelete);
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
