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
    
    public partial class Products_OrderProduct
    {
        public int Quantity { get; set; }
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }
        public int Id { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
