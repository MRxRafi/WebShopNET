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

        public double TotalPrice()
        {
            double totalPrice = 0;
            foreach(Products_OrderProduct orderProduct in this.Products_OrderProduct)
            {
                totalPrice += orderProduct.GetTotalPrice();
            }
            return totalPrice;
        }
    }
}