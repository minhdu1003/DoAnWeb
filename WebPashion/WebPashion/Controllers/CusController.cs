using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;

namespace WebPashion.Controllers
{
    public class CusController : Controller
    {
        // GET: Cus
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();
        [HttpGet]
       
        public ActionResult Index()
        {
            
            return View();
        }
       
        public JsonResult DsKhachhang( string tukhoa, int trang)
        {
            try
            {
                var pageSize = 10;
                data.Configuration.ProxyCreationEnabled = false;
                var dskhachhang =   data.CUSTOMER.ToList();
                var Pro = dskhachhang.OrderByDescending(x =>x.CustomerID).Where(x => x.CustomerName.ToLower().Contains(tukhoa.ToLower())).ToList();


                var pageNumber = Pro.Count() % pageSize;
                if (pageNumber == 0)
                {
                    pageNumber = Pro.Count() / pageSize;
                }
                else
                {
                    pageNumber = Pro.Count() / pageSize + 1;
                }
                var kqtk = Pro.Skip((trang - 1) * pageSize).Take(pageSize).ToList();
                return Json(new { code = 200, Sotrang = pageNumber , dskhachhang = kqtk, msg = "Thanh công !"  },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thất bại !"+ex.Message},JsonRequestBehavior.AllowGet);
            }
        }


        /// Xóa
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var Cus = data.CUSTOMER.SingleOrDefault(i => i.CustomerID == id);
                data.CUSTOMER.Remove(Cus);
                data.SaveChanges();
                return Json(new
                {
                    code = 200,
                    msg = "Xóa sản phẩm thành công!"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Xóa sản phẩm thất bại!" + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}