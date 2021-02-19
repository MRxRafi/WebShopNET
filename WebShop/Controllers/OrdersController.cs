using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private WebShopEntities db = new WebShopEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Client);
            orders = orders.Where(o => o.Client.Name.Equals(User.Identity.Name));
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create(ShoppingCart shoppingCart)
        {
            foreach (Products_OrderProduct orderProduct in shoppingCart)
            {
                db.Products_StoreProduct.Find(orderProduct.Id).Stock -= orderProduct.Quantity;
            }

            Client myClient = db.Clients.Where(client => client.Name.Equals(User.Identity.Name)).First();
            Order order = db.Orders.Add(new Order(shoppingCart, myClient));
            db.SaveChanges();
            shoppingCart.Clear();
            return RedirectToAction("Details", new { id = order.Id });
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
