using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public partial class Products_StoreProduct : Product
    {
        public Products_OrderProduct ToOrderProduct()
        {
            Products_OrderProduct orderProduct = new Products_OrderProduct();
            orderProduct.Id = this.Id;
            orderProduct.Name = this.Name;
            orderProduct.Price = this.Price;
            orderProduct.Section = this.Section;
            orderProduct.Quantity = 0;
            return orderProduct;
        }
    }
}