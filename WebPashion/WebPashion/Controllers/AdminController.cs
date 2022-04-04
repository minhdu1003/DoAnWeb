using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;
using WebPashion.Models;
using PagedList;

namespace WebPashion.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();
        public ActionResult IndexAdmin()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var name = f["user"];
            var pass = f["pass"];

            if (String.IsNullOrEmpty(name))
            {

            }
            else if (String.IsNullOrEmpty(pass))
            {

            }
            else
            {
                ADMIN ad = data.ADMIN.SingleOrDefault(n => n.Username == name && n.Password == pass);
                if (ad != null)
                {
                    Session["AccountAmin"] = ad;
                    return RedirectToAction("IndexAdmin", "Admin");
                }
                else
                {
                    ViewBag.tb = "Tên đăng nhập hoặc mật khẩu không đúng !";
                }
            }
            return View();
        }
        //
        public ActionResult GetProduct( int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                var ketQua = data.PRODUCT.OrderByDescending(x =>x.ProductCreatedDate.ToString()).ToList();

                return View(ketQua.ToPagedList(pageNum,pageSize));
            }

        }


       
        public ActionResult GetCustomer()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
            {
                return View(data.CUSTOMER.ToList());
            }
        }
  
        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            CUSTOMER ctm = data.CUSTOMER.SingleOrDefault(n => n.CustomerID == id);
            ViewBag.CustomerID = ctm.CustomerID;
            if (ctm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctm);
        }
        [HttpPost, ActionName("DeleteCustomer")]
        public ActionResult AcpDeleteCustomer(int id)
        {
            CUSTOMER ctm = data.CUSTOMER.SingleOrDefault(n => n.CustomerID == id);
            ViewBag.CustomerID = ctm.CustomerID;
            if (ctm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.CUSTOMER.Remove(ctm);
            data.SaveChanges();
            return RedirectToAction("GetCustomer");
        }
        //
        public ActionResult GetBill()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.BILL.ToList());
        }
        //Xóa
        [HttpGet]
        public ActionResult DeleteBill(int id)
        {
            BILL bill = data.BILL.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = bill.ID;
            if (bill == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bill);
        }
        [HttpPost, ActionName("DeleteBill")]

        public ActionResult AcpDeleteBill(int id)
        {
            BILL bill = data.BILL.SingleOrDefault(n => n.ID == id);
            ViewBag.ID = bill.ID;
            if (bill == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            data.BILL.Remove(bill);
            data.SaveChanges();
            return RedirectToAction("GetBill");
        }
        public ActionResult EditBill(int id)
        {
            BILL bill = data.BILL.SingleOrDefault(n => n.ID == id);
            if (bill == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bill);
        }
        [HttpPost]
        public ActionResult EditBill(int id, FormCollection collection)
        {
            var stastus = collection["Status"];
            var bill = data.BILL.SingleOrDefault(n => n.ID == id);
            if (string.IsNullOrEmpty(stastus))
            {
                ViewData["Loi"] = "kh dc de trong";
            }
            else
            {
                bill.Status = int.Parse( stastus.ToString());
                UpdateModel(bill);
                data.SaveChanges();
                return RedirectToAction("GetBill");
            }
            return this.EditBill(id);
        }
        ///Quản lý chi tiết
        public ActionResult GetDetailsBill()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.PRODUCT_DETAIL.ToList());
        }
        // Xóa
        [HttpGet]
        public ActionResult DeleteDetailsBill(int id)
        {
            PRODUCT_DETAIL detail = data.PRODUCT_DETAIL.SingleOrDefault(n => n.DetailID == id);
            ViewBag.DetailID = detail.DetailID;
            if (detail == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(detail);
        }
        [HttpPost, ActionName("DeleteDetailsBill")]

        public ActionResult AcpDeleteDetailsBill(int id)
        {
            PRODUCT_DETAIL detail = data.PRODUCT_DETAIL.SingleOrDefault(n => n.DetailID == id);
            ViewBag.DetailID = detail.DetailID;
            if (detail == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.PRODUCT_DETAIL.Remove(detail);
            data.SaveChanges();
            return RedirectToAction("GetDetailsBill");
        }
        // Quản lý size
        public ActionResult GetSize()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.PRODUCT_SIZE.ToList());
        }
        //Thêm size
        [HttpGet]
        public ActionResult AddSize()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSize(FormCollection f, PRODUCT_SIZE size)
        {
            var SizeName = f["sizename"];
            if (ModelState.IsValid)
            {
                size.SizeName = SizeName;
                data.PRODUCT_SIZE.Add(size);
                data.SaveChanges();
                return RedirectToAction("GetSize", "Admin");
            }
            else
            {
                return this.AddSize();
            }
           
        }
        // Xóa size
        [HttpGet]
        public ActionResult DeleteSize(int id)
        {
            PRODUCT_SIZE size = data.PRODUCT_SIZE.SingleOrDefault(n => n.Size == id);
            ViewBag.Brand = size.Size;
            if (size == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(size);
        }
        [HttpPost, ActionName("DeleteSize")]
        public ActionResult AcpDeleteSize(int id)
        {
            PRODUCT_SIZE size = data.PRODUCT_SIZE.SingleOrDefault(n => n.Size == id);
            ViewBag.Size = size.Size;
            if (size == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.PRODUCT_SIZE.Remove(size);
            data.SaveChanges();
            return RedirectToAction("GetSize");
        }
        //Sửa 
        [HttpGet]
        public ActionResult EditSize(int id)
        {
            PRODUCT_SIZE size = data.PRODUCT_SIZE.SingleOrDefault(n => n.Size == id);
            if (size == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(size);
        }
        [HttpPost]
        public ActionResult EditSize(int id, FormCollection collection)
        {
            var br = collection["SizeName"];
            var size = data.PRODUCT_SIZE.SingleOrDefault(n => n.Size == id);
            if (string.IsNullOrEmpty(br))
            {
                ViewData["Loi"] = "kh dc de trong";
            }
            else
            {
                size.SizeName = br;
                UpdateModel(size);
                data.SaveChanges();
                return RedirectToAction("GetSize");
            }
            return this.EditSize(id);
        }
        /// Quản lý sale

        public ActionResult GetSale()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.PRODUCT_SALE.ToList());
        }
        public ActionResult AddSale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSale(FormCollection f, PRODUCT_SALE sale)
        {
            var SaleName = f["salename"];
            if (ModelState.IsValid)
            {
                sale.SaleName = Int32.Parse(SaleName.ToString());
                data.PRODUCT_SALE.Add(sale);
                data.SaveChanges();
                return RedirectToAction("GetSale");
            }
            else
            {
                return this.AddSale();
            }

        }
        // Xóa sale
        [HttpGet]
        public ActionResult DeleteSale (int id)
        {
            PRODUCT_SALE sale = data.PRODUCT_SALE.SingleOrDefault(n => n.Sale == id);
            ViewBag.Sale = sale.Sale;
            if (sale == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sale);
        }
        [HttpPost, ActionName("DeleteSale")]
        public ActionResult AcpDeleteSale(int id)
        {
            PRODUCT_SALE sale = data.PRODUCT_SALE.SingleOrDefault(n => n.Sale == id);
            ViewBag.Sale = sale.Sale;
            if (sale == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.PRODUCT_SALE.Remove(sale);
            data.SaveChanges();
            return RedirectToAction("GetSale");
        }
        //Sửa 
        [HttpGet]
        public ActionResult EditSale(int id)
        {
            PRODUCT_SALE sale = data.PRODUCT_SALE.SingleOrDefault(n => n.Sale == id);
            if (sale == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sale);
        }
        [HttpPost]
        public ActionResult EditSale (int id, FormCollection collection)
        {
            var br = collection["SaleName"];
            var sale = data.PRODUCT_SALE.SingleOrDefault(n => n.Sale == id);
            if (string.IsNullOrEmpty(br))
            {
                ViewData["Loi"] = "kh dc de trong";
            }
            else
            {
                sale.SaleName = Int32.Parse(br.ToString());
                UpdateModel(sale);
                data.SaveChanges();
                return RedirectToAction("GetSale");
            }
            return this.EditSale(id);
        }
        /// Quản lý thương hiệu
        public ActionResult GetBrand()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.PRODUCT_BRAND.ToList());
        }
        //Thêm
        public ActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBrand(FormCollection f, PRODUCT_BRAND brand)
        {
            var BrandName = f["brandname"];
            if (ModelState.IsValid)
            {
                brand.BrandName = BrandName;
                data.PRODUCT_BRAND.Add(brand);
                data.SaveChanges();
                return RedirectToAction("GetBrand", "Admin");
            }
            else
            {
                return this.AddSize();
            }

        }
        //Xóa
        [HttpGet]
        public ActionResult DeleteBrand(int id)
        {
            PRODUCT_BRAND brand = data.PRODUCT_BRAND.SingleOrDefault(n => n.Brand == id);
            ViewBag.Brand = brand.Brand;
            if (brand == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(brand);
        }
        [HttpPost, ActionName("DeleteBrand")]
        public ActionResult AcpDeleteBrand(int id)
        {
            PRODUCT_BRAND brand = data.PRODUCT_BRAND.SingleOrDefault(n => n.Brand == id);
            ViewBag.Brand = brand.Brand;
            if (brand == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.PRODUCT_BRAND.Remove(brand);
            data.SaveChanges();
            return RedirectToAction("GetBrand");
        }
        //Sửa
        [HttpGet]
        public ActionResult EditBrand(int id)
        {
            PRODUCT_BRAND brand = data.PRODUCT_BRAND.SingleOrDefault(n => n.Brand == id);
            if (brand == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(brand);
        }
        [HttpPost]
        public ActionResult EditBrand(int id, FormCollection collection)
        {
            var br = collection["BrandName"];
            var brand = data.PRODUCT_BRAND.SingleOrDefault(n => n.Brand == id);
            if (string.IsNullOrEmpty(br))
            {
                ViewData["Loi"] = "kh dc de trong";
            }
            else
            {
                brand.BrandName = br;
                UpdateModel(brand);
                data.SaveChanges();
                return RedirectToAction("GetBrand");
            }
            return this.EditBrand(id);
        }
        ///end
        /// Quản lý loại sản phẩm
        public ActionResult GetTypeProduct()
        {
            if (Session["AccountAmin"] == null)
                return RedirectToAction("Login", "Admin");
            else
                return View(data.PRODUCT_TYPE.ToList());
        }

        // Thêm loại
        public ActionResult AddType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddType(FormCollection f, PRODUCT_TYPE type)
        {
            var hr = f["typename"];
            if (ModelState.IsValid)
            {
                type.TypeName = hr;
                data.PRODUCT_TYPE.Add(type);
                data.SaveChanges();
                return RedirectToAction("GetTypeProduct", "Admin");
            }
            else
            {
                return this.AddType();
            }

        }
        //Xóa
        [HttpGet]
        public ActionResult DeleteType(int id)
        {
            PRODUCT_TYPE type = data.PRODUCT_TYPE.SingleOrDefault(n => n.Type == id);
            ViewBag.Type = type.Type;
            if (type == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(type);
        }
        [HttpPost, ActionName("DeleteType")]
        public ActionResult AcpDeleteType(int id)
        {
            PRODUCT_TYPE type = data.PRODUCT_TYPE.SingleOrDefault(n => n.Type == id);
            ViewBag.Type = type.Type;
            if (type == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.PRODUCT_TYPE.Remove(type);
            data.SaveChanges();
            return RedirectToAction("GetTypeProduct");
        }
        //Sửa
        [HttpGet]
        public ActionResult EditType(int id)
        {
            PRODUCT_TYPE type = data.PRODUCT_TYPE.SingleOrDefault(n => n.Type == id);
            ViewBag.Type = type.Type;
            if (type == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(type);
        }
        [HttpPost]
        public ActionResult EditType(int id, FormCollection collection)
        {
            var br = collection["TypeName"];
            var type = data.PRODUCT_TYPE.SingleOrDefault(n => n.Type == id);
            if (string.IsNullOrEmpty(br))
            {
                ViewData["Loi"] = "kh dc de trong";
            }
            else
            {
                type.TypeName = br;
                UpdateModel(type);
                data.SaveChanges();
                return RedirectToAction("GetTypeProduct");
            }
            return this.EditType(id);
        }
  

    }
}