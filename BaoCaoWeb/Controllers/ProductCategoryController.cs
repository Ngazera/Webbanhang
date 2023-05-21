using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Controllers
{
    public class ProductCategoryController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: category
        public ActionResult ProductCategory(int ID)
        {
            var ListProduct = db.Products.Where(n => n.catId == ID).ToList();
            return View(ListProduct);
        }
    }
}