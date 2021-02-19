using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public partial class Order
    {
        public Order(ShoppingCart shoppingCart, Client client)
        {
            this.Client = client;
            this.Client_Id = client.Id;
            this.Date = DateTime.Now;
            this.Products_OrderProduct = shoppingCart;
        }
    }
}