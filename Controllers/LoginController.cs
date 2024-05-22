using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiSinhVien.Models;

namespace QuanLiSinhVien.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult login()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Role == "Admin" && model.TaiKhoan == "admin" && model.MatKhau == "123")
                {
                    // Lưu thông tin đăng nhập vào session
                    HttpContext.Session.SetString("User", model.TaiKhoan);
                    HttpContext.Session.SetString("Role", "Admin");

                    return RedirectToAction("Index", "Home");
                }
                else if (model.Role == "Giangvien")
                {
                    if (ValidateGiangvien(model.TaiKhoan, model.MatKhau))
                    {
                        HttpContext.Session.SetString("User", model.TaiKhoan);
                        HttpContext.Session.SetString("Role", "Giangvien");

                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (model.Role == "Sinhvien")
                {
                    if (ValidateSinhvien(model.TaiKhoan, model.MatKhau))
                    {
                        HttpContext.Session.SetString("User", model.TaiKhoan);
                        HttpContext.Session.SetString("Role", "Sinhvien");

                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }

        // Đăng xuất
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private bool ValidateGiangvien(string maGv, string sdt)
        {
            var context = new QlsinhvienContext();
            var giangvien = context.Giangviens.FirstOrDefault(gv => gv.MaGv == maGv && gv.Sdt == sdt);
            return giangvien != null;
        }

        private bool ValidateSinhvien(string maSv, string sdt)
        {
            var context = new QlsinhvienContext();
            var sinhvien = context.Sinhviens.FirstOrDefault(sv => sv.MaSv == maSv && sv.Sdt == sdt);
            return sinhvien != null;
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
