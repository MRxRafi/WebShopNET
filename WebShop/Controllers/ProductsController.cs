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
    public class ProductsController : Controller
    {
        private WebShopEntities db = new WebShopEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products_StoreProduct.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_StoreProduct products_StoreProduct = db.Products_StoreProduct.Find(id);
            if (products_StoreProduct == null)
            {
                return HttpNotFound();
            }
            return View(products_StoreProduct);
        }

        // GET: Products/Create
        [Authorize(Users = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Img,Stock,Name,Price,Section")] Products_StoreProduct products_StoreProduct)
        {
            if (ModelState.IsValid)
            {
                db.Products_StoreProduct.Add(products_StoreProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products_StoreProduct);
        }

        // GET: Products/Edit/5
        [Authorize(Users = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_StoreProduct products_StoreProduct = db.Products_StoreProduct.Find(id);
            if (products_StoreProduct == null)
            {
                return HttpNotFound();
            }
            return View(products_StoreProduct);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Img,Stock,Name,Price,Section")] Products_StoreProduct products_StoreProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products_StoreProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products_StoreProduct);
        }

        // GET: Products/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_StoreProduct products_StoreProduct = db.Products_StoreProduct.Find(id);
            if (products_StoreProduct == null)
            {
                return HttpNotFound();
            }
            return View(products_StoreProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products_StoreProduct products_StoreProduct = db.Products_StoreProduct.Find(id);
            db.Products_StoreProduct.Remove(products_StoreProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id, ShoppingCart shoppingCart)
        {
            Products_StoreProduct storeProduct = db.Products_StoreProduct.Find(id);
            Products_OrderProduct orderProduct = shoppingCart.Find(p => p.Id == storeProduct.Id);
            if (orderProduct == null)
            {
                orderProduct = storeProduct.ToOrderProduct();
                shoppingCart.Add(orderProduct);
                
            }
            orderProduct.Quantity += 1;
            return RedirectToAction("Index");
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
