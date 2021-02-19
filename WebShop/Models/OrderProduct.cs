using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public partial class Products_OrderProduct
    {
        public double GetTotalPrice()
        {
            return this.Price * this.Quantity;
        }
    }
}