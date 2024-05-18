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

        // GET: LshController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LshController/Delete/5
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
