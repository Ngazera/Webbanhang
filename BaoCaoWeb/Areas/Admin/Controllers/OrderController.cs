using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Admin/Order
        public ActionResult Index()
        {
            //var objnew = db.Orders.OrderByDescending(n => n.id);
            // return View(objnew);
            //    db.Orders.ToList()
            List<Order> DanhsachSlider = db.Orders.OrderByDescending(n => n.id).ToList();
            return View(DanhsachSlider);
       
        }
        public ActionResult Xoa(int id)
        {
            // tìm đối tượng
            var updateModel = db.Orders.Find(id);
            //lệnh xoá
            db.Orders.Remove(updateModel);
            // lưu thay đổi 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       

        
    }
}