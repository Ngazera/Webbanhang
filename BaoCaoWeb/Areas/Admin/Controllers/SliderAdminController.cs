using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Areas.Admin.Controllers
{
    public class SliderAdminController : Controller
    {
       
  
        AnnaShopEntities2 db = new AnnaShopEntities2();
        // GET: Admin/SliderAdmin
        public ActionResult Index()
        {
            List<Slider> DanhsachSlider = db.Sliders.ToList();
            return View(DanhsachSlider);
        }
        public ActionResult ThemMoi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(Slider model, HttpPostedFileBase fileAnh)
        {
            if (fileAnh.ContentLength > 0)
            {
                // Lưu file
                string rootFolder = Server.MapPath("/image/slider/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model.slider_image= "/image/slider/" + fileAnh.FileName;
            }
            //2. Thêm mới bản ghi

            db.Sliders.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CapNhat(int id)
        {
            //3. Tìm đối tượng theo id

            // KhachHang model = db.KhachHangs.SingleOrDefault(m => m.ID == id);
            Slider model = db.Sliders.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(Slider model, HttpPostedFileBase fileAnh)
        {
            if (fileAnh.ContentLength > 0)
            {
                // Lưu file
                string rootFolder = Server.MapPath("/image/slider/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model.slider_image = "/image/slider/" + fileAnh.FileName;
            }
            // tìm đối tượng
            var updateModel = db.Sliders.Find(model.sliderId);
            // Gán giá trị
            updateModel.sliderName = model.sliderName;
            updateModel.slider_image = model.slider_image;
            // lưu thay đổi
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Xoa(int id)
        {
            // tìm đối tượng
            var updateModel = db.Sliders.Find(id);
            //lệnh xoá
            db.Sliders.Remove(updateModel);
            // lưu thay đổi 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}