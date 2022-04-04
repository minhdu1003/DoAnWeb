using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;

namespace WebPashion.Controllers
{
    public class BillController : Controller
    {
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DsDonhang(string tukhoa, int trang)
        {
            try
            {
                var pageSize = 10;
                data.Configuration.ProxyCreationEnabled = false;
                var dsdonhang = data.BILL.ToList();
                var Pro = dsdonhang.OrderByDescending(x => x.DateCreated).Where(x => x.DateCreated.ToString().ToLower().Contains(tukhoa.ToLower())|| x.CUSTOMER.CustomerName.ToLower().Contains(tukhoa.ToLower())).ToList();


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
                return Json(new { code = 200, Sotrang = pageNumber, dsbill = kqtk, msg = "Thanh công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult Details(int id)
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;
                var product = data.PRODUCT_DETAIL.Where(c => c.BillID == id).Select(c => new {
                    receiverAddress = c.BILL.receiverAddress,
                    BillID = c.BILL.ID,
                    Status = c.BILL.Status,
                    DetailID = c.DetailID,
                    ProductName = c.PRODUCT.ProductName,
                    ProductImage = c.PRODUCT.ProductImage,
                    ProductCount = c.ProductCount,
                    Note = c.Note
                }).ToList();
                return Json(new
                {
                    code = 200,
                    product = product,
                    msg = "Load thành công!"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Load  thất bại!" + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Bill(int id)
        {
            try
            {
                data.Configuration.ProxyCreationEnabled = false;
                var product = data.BILL.Where(c => c.ID == id).ToList();

                return Json(new
                {
                    code = 200,
                    product = product,
                    msg = "Load thành công!"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Load  thất bại!" + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var bill = data.BILL.SingleOrDefault(i => i.ID == id);
                data.BILL.Remove(bill);
                data.SaveChanges();
                return Json(new
                {
                    code = 200,
                    msg = "Xóa  thành công!"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Xóa  thất bại!" + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ChangStatus(int id)
        {
            try
            {
                BILL bill = data.BILL.Where(c => c.ID == id).FirstOrDefault();
                if (bill.Status == 0)
                {
                    bill.Status = 1;
                    data.SaveChanges();
                }
                else
                {
                    bill.Status = 0;
                    data.SaveChanges();
                }

                return Json(new
                {
                    code = 200,
                    msg = "Cập nhật trạng thái thành công!"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = 500,
                    msg = "Cập nhật thất bại: " + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}