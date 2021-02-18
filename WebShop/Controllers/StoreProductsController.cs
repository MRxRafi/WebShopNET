using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class StoreProductsController : ApiController
    {
        private WebShopEntities db = new WebShopEntities();

        // GET: api/StoreProducts
        public IQueryable<Products_StoreProduct> GetProducts()
        {
            return db.Products_StoreProduct;
        }

        // GET: api/StoreProducts/5
        [ResponseType(typeof(Products_StoreProduct))]
        public IHttpActionResult GetProducts_StoreProduct(int id)
        {
            Products_StoreProduct products_StoreProduct = db.Products_StoreProduct.Find(id);
            if (products_StoreProduct == null)
            {
                return NotFound();
            }

            return Ok(products_StoreProduct);
        }

        // PUT: api/StoreProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducts_StoreProduct(int id, Products_StoreProduct products_StoreProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products_StoreProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(products_StoreProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Products_StoreProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StoreProducts
        [ResponseType(typeof(Products_StoreProduct))]
        public IHttpActionResult PostProducts_StoreProduct(Products_StoreProduct products_StoreProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products_StoreProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products_StoreProduct.Id }, products_StoreProduct);
        }

        // DELETE: api/StoreProducts/5
        [ResponseType(typeof(Products_StoreProduct))]
        public IHttpActionResult DeleteProducts_StoreProduct(int id)
        {
            Products_StoreProduct products_StoreProduct = db.Products_StoreProduct.Find(id);
            if (products_StoreProduct == null)
            {
                return NotFound();
            }

            db.Products.Remove(products_StoreProduct);
            db.SaveChanges();

            return Ok(products_StoreProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Products_StoreProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}