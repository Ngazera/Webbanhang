using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCaoWeb.Models;
namespace BaoCaoWeb.Controllers
{
    public class HomeController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Home
        public ActionResult Index()
        {
          
            List<Product> sanpham = db.Products.ToList();
        
            //1. Lấy danh sách dữ liệu trong bảng
           
            return View(sanpham);
        }
        public ActionResult slider()
        {
            AnnaShopEntities2 db = new AnnaShopEntities2();
            List<Slider> sl = db.Sliders.ToList();
            //1. Lấy danh sách dữ liệu trong bảng
            return PartialView(sl);
        }

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.email == _user.email);
                if (check == null)
                {
                    //_user.Password = GetMD5(_user.Password);
                  //  db.Configuration.ValidateOnSaveEnabled = false;
                    db.Customers.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(String user, String pass)
        {
            if (ModelState.IsValid)
            {
                var data = db.Customers.Where(s => s.email.Equals(user) && s.password.Equals(pass)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["id"] = data.FirstOrDefault().customer_id;
                    Session["Email"] = data.FirstOrDefault().email;
                    Session["idUser"] = data.FirstOrDefault().password;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("DangNhap");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("DangNhap");
        }



        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            var category = db.Categories.ToList();

            ViewBag.category = category;
            return PartialView("_nva");
        }

    }
}
