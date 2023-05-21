using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {

        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["ten"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                return View();
            }
           
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
                var data = db.Admins.Where(s => s.adminName.Equals(user) && s.adminPass.Equals(pass)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Ten"] = data.FirstOrDefault().adminName;
                    Session["matkhau"] = data.FirstOrDefault().adminPass;
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
    }
}