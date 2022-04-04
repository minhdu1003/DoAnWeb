using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;
using PagedList;
        

namespace WebPashion.Controllers
{
    public class HomeController : Controller
    {
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();
        public ActionResult Index()
        {
            ViewBag.Ao = data.PRODUCT.Where(x => x.Type == 1).Take(8).ToList();
            ViewBag.Quan = data.PRODUCT.Where(x => x.Type == 2).Take(4).ToList();
            ViewBag.Vay = data.PRODUCT.Where(x => x.Type == 3).Take(4).ToList();
            ViewBag.PhuKien = data.PRODUCT.Where(x => x.Type == 4).Take(4).ToList();
            ViewBag.SanPhamMoi = data.PRODUCT.OrderByDescending(x => x.ProductCreatedDate).Take(4).ToList();
            ViewBag.SanPhamBanChay = data.PRODUCT.OrderByDescending(x => x.ProductCount).Take(4).ToList();
            return View();
        }  
        
        //Login thành công
        //Load danh sách áo 
        public ActionResult GetShirt(int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var shirt = data.PRODUCT.Where(x => x.Type == 1).ToList();
            return View(shirt.ToPagedList(pageNum,pageSize));
        }
        //Load danh sách quần 
        public ActionResult GetTrousers(int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var shirt = data.PRODUCT.Where(x => x.Type == 2).ToList();
            return View(shirt.ToPagedList(pageNum, pageSize));
        }
        //Load danh sách đầm
        public ActionResult GetDresses(int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var shirt = data.PRODUCT.Where(x => x.Type == 3).ToList();
            return View(shirt.ToPagedList(pageNum, pageSize));
        }   
        //Load danh sách phụ kiện
        public ActionResult GetAccessories(int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var shirt = data.PRODUCT.Where(x => x.Type == 4).ToList();
            return View(shirt.ToPagedList(pageNum, pageSize));
        }
        //Load contac
        public ActionResult Contact()
        {
            return View();
        }
        //Load chi tiết sản phẩm
        public ActionResult GetDetail(int id)
        {

            PRODUCT sp = data.PRODUCT.SingleOrDefault(x => x.ID == id);
            //Nếu không tìm thấy
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult About()
        {
            return View();
        }

       
    }
}
