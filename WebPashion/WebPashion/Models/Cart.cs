using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPashion.Models
{
    public class Cart
    {
        FashionShopManagemnetConnec data = new FashionShopManagemnetConnec();
        public int iID { get; set; }
        public string sProductName { get; set; }
        public string sProductImage { get; set; }
        public double iProductPrice { get; set; }
        public int iCount { get; set; }

        public string sSize { get; set; }
        public Double dMoney {

            get { return iCount * iProductPrice; }
        }

        public Cart(int ID)
        {
            iID = ID;
            PRODUCT product = data.PRODUCT.Single(n => n.ID == iID);
            sProductName = product.ProductName;
            sProductImage = product.ProductImage;
            iProductPrice = double.Parse(product.ProductPrice.ToString());
            sSize = product.PRODUCT_SIZE.SizeName;
            iCount = 1;
        }
    }
}