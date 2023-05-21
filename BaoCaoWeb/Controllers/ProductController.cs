using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCaoWeb.Models;
namespace BaoCaoWeb.Controllers
{
    public class ProductController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Chitietsanpham
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Chitietsanpham(int ID)
        {
            var objProduct = db.Products.Where(n => n.productId == ID).FirstOrDefault();
            return View(objProduct);


        }
        public ActionResult NewProduct()
        {
            var objnew = db.Products.OrderByDescending(n => n.productId );
            return View(objnew);
        }
        public ActionResult Introduce()
        {

            return View();
        }

    }
}