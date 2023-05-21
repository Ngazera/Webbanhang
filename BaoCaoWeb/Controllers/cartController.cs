using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaoCaoWeb.Models;
namespace BaoCaoWeb.Controllers
{
    public class cartController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: cart
        public ActionResult Index()
        {
            List<Cart> listcart = (List<Cart>)Session["listcart"];
            if (listcart == null)
            {
                listcart = new List<Cart>();
            }

            return View(listcart);

        }

        public RedirectToRouteResult AddToCart(int ProductId)
        {
            List<Cart> listcart = (List<Cart>)Session["listcart"];
            if (listcart == null)
            {
                listcart = new List<Cart>();
            }
            Cart obj = listcart.FirstOrDefault(x => x.productId == ProductId);
            if (obj != null)
            {
                obj.quantity++;
            }
            else
            {
                var product = db.Products.Find(ProductId);
                obj = new Cart();
                obj.productId = ProductId;
                obj.productName = product.productName;
                obj.price = product.price;
                obj.image = product.image;
                obj.quantity = 1;
                listcart.Add(obj);
            }
            Session["listcart"] = listcart;

            return RedirectToAction("Index", "cart");
        }
        public RedirectToRouteResult UpdateAmount(int ProductId, int newAmount)
        {
            // tìm carditem muon sua
            List<Cart> listcart = (List<Cart>)Session["listcart"];
            Cart EditAmount = listcart.FirstOrDefault(m => m.productId == ProductId);
            if (EditAmount != null)
            {
                EditAmount.quantity = newAmount;
            }
            return RedirectToAction("Index");

        }
        public RedirectToRouteResult RemoveItem(int ProductId)
        {
            List<Cart> listcart = (List<Cart>)Session["listcart"];
            Cart DelItem = listcart.FirstOrDefault(m => m.productId == ProductId);
            if (DelItem != null)
            {
                listcart.Remove(DelItem);
            }
            return RedirectToAction("Index");
        }

        //Hien thi View DatHang de cap nhat cac thong tin cho Don hang [HttpGet]
      
           public ActionResult DatHang()
        {
            //Kiem tra dang nhap 
            if (Session["Email"] == null || Session["Email"].ToString()=="")
            {


                return RedirectToAction("DangNhap","Home");
            }

            if (Session["listcart"] == null)
            { 
            return RedirectToAction("Index", "Home");
            }
            //Lay gio hang tu Session
            List<Cart> listcart = (List<Cart>)Session["listcart"];
            foreach (var item in listcart) {
                Order objOrder = new Order();
         
                objOrder.productId = item.productId;
                objOrder.customer_id = int.Parse(Session["id"].ToString());
                objOrder.image = item.image;
                objOrder.price = item.price;
                objOrder.date_order = DateTime.Now;
                objOrder.productName = item.productName;
                objOrder.quantity = item.quantity;
                objOrder.total = item.money.ToString();
        
                db.Orders.Add(objOrder);
               db.SaveChanges();
            }

            //luu tt dữ liệu vào bảng order
            // List<Cart> 1stGiohang = Laygiohang();
            // ViewBag.Tongsoluong= TongSoLuong();
            // ViewBag.Tongtien = TongTien();
            return View();
        }
        //public PartialViewResult BagCart()
        //{
     
        //    List<Cart> listcart = (List<Cart>)Session["listcart"];

        //    if (listcart != null)
        //    {
        //        int  tong =   listcart.Sum(s => s.quantity);
        //       }
                
            
        //    //ViewBag.inCart = tong;
        //    return PartialView();
        //}
    }
}