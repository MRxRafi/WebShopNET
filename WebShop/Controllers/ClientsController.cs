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
    public class ClientsController : Controller
    {
        private WebShopEntities db = new WebShopEntities();

        public ActionResult Create(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
