//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products_StoreProduct
    {
        public string Img { get; set; }
        public int Stock { get; set; }
        public int Id { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
