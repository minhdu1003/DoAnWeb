using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;

namespace WebPashion.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();

        public List<Cart> GetCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }

        public ActionResult AddCart(int iID, string strURL)
        {
            List<Cart> lstCart = GetCart();
            Cart product = lstCart.Find(n => n.iID == iID);
            if (product == null)
            {
                product = new Cart(iID);
                lstCart.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.iCount++;
                return Redirect(strURL);
            }
        }
        private int SumCount()
        {
            int iCount = 0;
            List<Cart> lsCart = Session["Cart"] as List<Cart>;
            if (lsCart != null)
            {
                iCount = lsCart.Sum(n => n.iCount);

            }
            return iCount;
        }

        private double SumMoney()
        {
            double iMoney = 0;
            List<Cart> lsCart = Session["Cart"] as List<Cart>;
            if (lsCart != null)
            {
                iMoney = lsCart.Sum(n => n.dMoney);
            }
            return iMoney;
        }

        public ActionResult Cart()
        {
            List<Cart> lstCart = GetCart();
            if (lstCart.Count == 0)
            {
                return RedirectToAction("ContiniueCart", "Cart");

            }

            ViewBag.SumCount = SumCount();
            ViewBag.SumMoney = SumMoney();

            return View(lstCart);
        }

        public ActionResult CartPartial()
        {
            ViewBag.SumCount = SumCount();
            return PartialView();
        }

        // Xóa sản phẩm trong giỏ hàng
        public ActionResult DeleteCart(int id)
        {
            List<Cart> lstCart = GetCart();

            Cart cart = lstCart.SingleOrDefault(n => n.iID == id);

            if (cart != null)
            {
                lstCart.RemoveAll(n => n.iID == id);
                return RedirectToAction("Cart");
            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("ContiniueCart", "Cart");
            }
            return RedirectToAction("Cart");
        }
        //
        public ActionResult ContiniueCart()
        {
            return View();
        }
        //Cập nhật giỏ hàng
        public ActionResult UpdateCart(int id, FormCollection collection)
        {
            List<Cart> lstCart = GetCart();

            Cart cart = lstCart.SingleOrDefault(n => n.iID == id);
            if (cart != null)
            {
                cart.sSize = collection["size"];
                cart.iCount = int.Parse(collection["count"].ToString());

            }
            return RedirectToAction("Cart");
        }
        //Xóa giỏ hàng
        public ActionResult DeleteAllCart()
        {
            List<Cart> lstCart = GetCart();
            lstCart.Clear();
            return RedirectToAction("ContiniueCart", "Cart");
        }
        //Thanh toán

        public ActionResult Order()
        {
            if (Session["account"] == null || Session["account"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Cart> lstCart = GetCart();

            ViewBag.SumCount = SumCount();
            ViewBag.SumMoney = SumMoney();

            return View(lstCart);
        }

        [HttpPost]
        public ActionResult Order(FormCollection collection)
        {
            ViewBag.SumMoney = SumMoney();
            BILL bill = new BILL();
            CUSTOMER customer = (CUSTOMER)Session["account"];
            List<Cart> cart = GetCart();
            bill.CustomerID = customer.CustomerID;
            bill.DateCreated = DateTime.Now;
            bill.TotalMoney = (decimal)ViewBag.SumMoney;
            var status = 0;
            var name = collection["namereceiver"];
            var address = collection["addressreceiver"];
            var phone = collection["phonereceiver"];

            bill.Status = status;
            bill.ReceiverName = name;
            bill.ReceiverPhone = phone;
            bill.receiverAddress = address;

            data.BILL.Add(bill);
            data.SaveChanges();
            foreach(var iteam in cart)
            {
                PRODUCT_DETAIL detail = new PRODUCT_DETAIL();
                detail.BillID = bill.ID;
                detail.ProductID = iteam.iID;
                detail.ProductCount = iteam.iCount;
                detail.Note = iteam.sSize;
                data.PRODUCT_DETAIL.Add(detail);
            }
            data.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("ConfirmOrder", "Cart");
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }
    }
}