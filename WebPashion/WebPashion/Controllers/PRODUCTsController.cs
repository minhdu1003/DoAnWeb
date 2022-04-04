using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;
using PagedList;
using PagedList.Mvc;

namespace WebPashion.Controllers
{
    public class PRODUCTsController : Controller
    {
        private FashionShopManagemnetConnec db = new FashionShopManagemnetConnec();

        // GET: PRODUCTs
        public ActionResult Index( int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var pRODUCT = db.PRODUCT.Include(p => p.PRODUCT_BRAND).Include(p => p.PRODUCT_SALE).Include(p => p.PRODUCT_SIZE).Include(p => p.PRODUCT_TYPE).ToList();
            return View(pRODUCT.ToPagedList(pageNum,pageSize));
        }

        // GET: PRODUCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(db.PRODUCT_BRAND, "Brand", "BrandName");
            ViewBag.Sale = new SelectList(db.PRODUCT_SALE, "Sale", "Sale");
            ViewBag.Size = new SelectList(db.PRODUCT_SIZE, "Size", "SizeName");
            ViewBag.Type = new SelectList(db.PRODUCT_TYPE, "Type", "TypeName");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Size,Type,Brand,Sale,Note")] PRODUCT pRODUCT, HttpPostedFileBase ImageUpload,FormCollection f)
        {
        
            if (ModelState.IsValid) 
            {
                var filename = Path.GetFileName(ImageUpload.FileName);
                var name = f["textname"];
                var money = f["money"];
                var count = f["count"];
                var path = Path.Combine(Server.MapPath("~/Content/images/IMG"), filename);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    ImageUpload.SaveAs(path);
                }
                pRODUCT.ProductCount = int.Parse(count);
                pRODUCT.ProductPrice = int.Parse(money);
                pRODUCT.ProductName = name;
                pRODUCT.ProductImage = filename;
                pRODUCT.ProductCreatedDate = DateTime.Now;
                db.PRODUCT.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Create","PRODUCTs");
            }

            ViewBag.Brand = new SelectList(db.PRODUCT_BRAND, "Brand", "BrandName", pRODUCT.Brand);
            ViewBag.Sale = new SelectList(db.PRODUCT_SALE, "Sale", "Sale", pRODUCT.Sale);
            ViewBag.Size = new SelectList(db.PRODUCT_SIZE, "Size", "SizeName", pRODUCT.Size);
            ViewBag.Type = new SelectList(db.PRODUCT_TYPE, "Type", "TypeName", pRODUCT.Type);

            return View(pRODUCT);
        } 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand = new SelectList(db.PRODUCT_BRAND, "Brand", "BrandName", pRODUCT.Brand);
            ViewBag.Sale = new SelectList(db.PRODUCT_SALE, "Sale", "Sale", pRODUCT.Sale);
            ViewBag.Size = new SelectList(db.PRODUCT_SIZE, "Size", "SizeName", pRODUCT.Size);
            ViewBag.Type = new SelectList(db.PRODUCT_TYPE, "Type", "TypeName", pRODUCT.Type);
            return View(pRODUCT);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,ProductPrice,ProductCount,Size,Type,Brand,Sale,ProductCreatedDate,Note")] PRODUCT pRODUCT, HttpPostedFileBase ImageUpload)
        {
            var filename = Path.GetFileName(ImageUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/images/IMG"), filename);
            if (System.IO.File.Exists(path))
            {
                ViewBag.Thongbao = "Hình ảnh đã tồn tại";
            }
            else
            {
                ImageUpload.SaveAs(path);
            }
            pRODUCT.ProductImage = filename;
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetProduct","Admin");
            }
            ViewBag.Brand = new SelectList(db.PRODUCT_BRAND, "Brand", "BrandName", pRODUCT.Brand);
            ViewBag.Sale = new SelectList(db.PRODUCT_SALE, "Sale", "Sale", pRODUCT.Sale);
            ViewBag.Size = new SelectList(db.PRODUCT_SIZE, "Size", "SizeName", pRODUCT.Size);
            ViewBag.Type = new SelectList(db.PRODUCT_TYPE, "Type", "TypeName", pRODUCT.Type);
            return View(pRODUCT);
        }

  
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            db.PRODUCT.Remove(pRODUCT);
            db.SaveChanges();
            return RedirectToAction("GetProduct", "Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
