using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            List<Product> DanhsachSanPham = db.Products.ToList();
            DanhsachSanPham.OrderByDescending(n => n.productId);
            return View(DanhsachSanPham);
        }
        public ActionResult ThemMoi()
        {

            return View();
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult ThemMoi(Product model, HttpPostedFileBase fileAnh)
        { 
            if (fileAnh.ContentLength > 0)
            {
                // Lưu file
                string rootFolder = Server.MapPath("/image/imageHome/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model.image = "/image/imageHome/"+ fileAnh.FileName;
            }
          
            //2. Thêm mới bản ghi

            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CapNhat(int id)
        {
            //3. Tìm đối tượng theo id

            // KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            Product model = db.Products.Find(id);
            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult CapNhat(Product model, HttpPostedFileBase fileAnh)
        {
            
                if (fileAnh.ContentLength > 0)
                {
                    // Lưu file
                    string rootFolder = Server.MapPath("/image/imageHome/");
                    string pathImage = rootFolder + fileAnh.FileName;
                    fileAnh.SaveAs(pathImage);
                    model.image = "/image/imageHome/" + fileAnh.FileName;

                }
                    // tìm đối tượng
                    var updateModel = db.Products.Find(model.productId);

                    // Gán giá trị
                    updateModel.productName = model.productName;
                    updateModel.quantity = model.quantity;
                    updateModel.price = model.price;
                    updateModel.catId = model.catId;
                    updateModel.description = model.description;
                    updateModel.image = model.image;

                    // lưu thay đổỉ
            
            
         
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Xoa(int id)
        {
            // tìm đối tượng
            var updateModel = db.Products.Find(id);
            //lệnh xoá
            db.Products.Remove(updateModel);
            // lưu thay đổi 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}