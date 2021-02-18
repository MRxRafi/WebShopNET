using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Models.Binders
{
    public class ShoppingCartModelBinder : IModelBinder
    {
        private static string KEY_CART = "CART";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Acceder a session
            ShoppingCart cart = (ShoppingCart)controllerContext.HttpContext.Session[ShoppingCartModelBinder.KEY_CART];
            if (cart == null)
            {
                cart = new ShoppingCart();
                controllerContext.HttpContext.Session[ShoppingCartModelBinder.KEY_CART] = cart;

            }
            return cart;
        }
    }
}