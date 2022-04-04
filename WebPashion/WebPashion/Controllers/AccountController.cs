using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPashion.Models;

namespace WebPashion.Controllers
{
    public class AccountController : Controller
    {
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registor(FormCollection collection, CUSTOMER kh)
        {
            var name = collection["Name"];
            var sex = collection["Sex"];
            var number = collection["Phonenumber"];
            var address = collection["Address"];
            var email = collection["Email"];
            var username = collection["Username"];
            var password = collection["Password"];

            if (ModelState.IsValid)
            {
                kh.CustomerName = name;
                kh.CustomerSex = sex;
                kh.CustomerPhone = number;
                kh.CustomerAddress = address;
                kh.CustomerEmail = email;
                kh.Username = username;
                kh.Password = password;
                data.CUSTOMER.Add(kh);
                data.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return this.Registor();
            }
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["username"];
            var password = collection["password"];


            if (String.IsNullOrEmpty(username))
            {
                ViewData["Enron1"] = "Tên đăng nhập không được trống";
            }
            else if (String.IsNullOrEmpty(password))
                 {
                ViewData["Enron2"] = "Mật khẩu không được trống";
            }
            else
            {
                CUSTOMER customer = data.CUSTOMER.SingleOrDefault(n => n.Username == username && n.Password == password);
                if (customer != null)
                {
                   ViewBag.Notification = "Đăng nhập thành công !";
                    Session["Name"] = customer.CustomerName;
                    Session["account"] = customer;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Notification = "Tên đăng nhập hoặc mật khẩu không đúng !";
            }
            return this.Login();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult InfoLogin()
        {
            return PartialView();
        }

        public ActionResult NameLogin()
        {

            return PartialView();
        }
    }
}