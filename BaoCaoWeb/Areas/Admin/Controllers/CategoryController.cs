using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Areas.Admin.Controllers
{
    
    public class CategoryController : Controller
    {
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhMucSanPham()
        {
            List<Category> DanhMucSanPham = db.Categories.ToList();
            return View(DanhMucSanPham);
        }
        public ActionResult ThemMoi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(Category model)
        {
            //2. Thêm mới bản ghi
    
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham");
        }
        public ActionResult CapNhat(int id)
        {
            //3. Tìm đối tượng theo id
          
            // KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            Category model = db.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(Category model)
        {
         
            // tìm đối tượng
            var updateModel = db.Categories.Find(model.catId);
            // Gán giá trị
            updateModel.catName = model.catName;
           
            // lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham");
        }
        public ActionResult Xoa(int id)
        {
            // tìm đối tượng
            var updateModel = db.Categories.Find(id);
            //lệnh xoá
            db.Categories.Remove(updateModel);
            // lưu thay đổi 
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham");
        }
    }
}