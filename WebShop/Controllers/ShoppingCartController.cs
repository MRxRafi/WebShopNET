using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index(ShoppingCart shoppingCart)
        {
            return View(shoppingCart);
        }

        public ActionResult Delete(int id, ShoppingCart shoppingCart)
        {
            try
            {
                Products_OrderProduct orderProduct = shoppingCart.Find(p => p.Id == id);
                orderProduct.Quantity--;
                if (orderProduct.Quantity <= 0) {
                    shoppingCart.Remove(orderProduct);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
