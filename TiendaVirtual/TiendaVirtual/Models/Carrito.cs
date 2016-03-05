using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public class Carrito : List<Producto>
    {
        public double precioTotal { get; set; }
        public Carrito()
        {
            this.precioTotal = 0;
        }
    }
}